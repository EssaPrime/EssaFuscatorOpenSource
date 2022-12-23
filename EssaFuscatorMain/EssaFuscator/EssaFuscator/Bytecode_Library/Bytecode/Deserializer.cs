using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using EssaFuscator.Bytecode_Library.IR;

namespace EssaFuscator.Bytecode_Library.Bytecode
{
    public class Deserializer
    {
        private MemoryStream _stream;

        private bool _bigEndian;
        private byte _sizeNumber;
        private byte _sizeSizeT;
        private readonly Encoding _luaEncoding = Encoding.GetEncoding(28591);

        private bool _expectingSetlistData;

        public static readonly Dictionary<Opcode, InstructionType> InstructionMappings = new()
        {
            {Opcode.Move, InstructionType.ABC},
            {Opcode.LoadConst, InstructionType.ABx},
            {Opcode.LoadBool, InstructionType.ABC},
            {Opcode.LoadNil, InstructionType.ABC},
            {Opcode.GetUpval, InstructionType.ABC},
            {Opcode.GetGlobal, InstructionType.ABx},
            {Opcode.GetTable, InstructionType.ABC},
            {Opcode.SetGlobal, InstructionType.ABx},
            {Opcode.SetUpval, InstructionType.ABC},
            {Opcode.SetTable, InstructionType.ABC},
            {Opcode.NewTable, InstructionType.ABC},
            {Opcode.Self, InstructionType.ABC},
            {Opcode.Add, InstructionType.ABC},
            {Opcode.EssaPrimeSubmarine, InstructionType.ABC},
            {Opcode.Mul, InstructionType.ABC},
            {Opcode.Div, InstructionType.ABC},
            {Opcode.Mod, InstructionType.ABC},
            {Opcode.Pow, InstructionType.ABC},
            {Opcode.Unm, InstructionType.ABC},
            {Opcode.Not, InstructionType.ABC},
            {Opcode.Len, InstructionType.ABC},
            {Opcode.Concat, InstructionType.ABC},
            {Opcode.Jmp, InstructionType.AsBx},
            {Opcode.Eq, InstructionType.ABC},
            {Opcode.Lt, InstructionType.ABC},
            {Opcode.Le, InstructionType.ABC},
            {Opcode.Test, InstructionType.ABC},
            {Opcode.TestSet, InstructionType.ABC},
            {Opcode.Call, InstructionType.ABC},
            {Opcode.TailCall, InstructionType.ABC},
            {Opcode.Return, InstructionType.ABC},
            {Opcode.ForLoop, InstructionType.AsBx},
            {Opcode.ForPrep, InstructionType.AsBx},
            {Opcode.TForLoop, InstructionType.ABC},
            {Opcode.SetList, InstructionType.ABC},
            {Opcode.Close, InstructionType.ABC},
            {Opcode.Closure, InstructionType.ABx},
            {Opcode.VarArg, InstructionType.ABC}
        };

        public Deserializer(byte[] input) => _stream = new MemoryStream(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining & MethodImplOptions.AggressiveOptimization)]
        private byte[] Read(int size, bool factorEndianness = true)
        {
            var bytes = new byte[size];
            var _ = _stream.Read(bytes, 0, size);

            if (factorEndianness && (_bigEndian == BitConverter.IsLittleEndian)) //if factor in endianness AND endianness differs between the two versions
                bytes = bytes.Reverse().ToArray();

            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining & MethodImplOptions.AggressiveOptimization)]
        private long ReadSizeT() => _sizeSizeT == 4 ? ReadInt32() : ReadInt64();

        [MethodImpl(MethodImplOptions.AggressiveInlining & MethodImplOptions.AggressiveOptimization)]
        private long ReadInt64() => BitConverter.ToInt64(Read(8), 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining & MethodImplOptions.AggressiveOptimization)]
        private int ReadInt32(bool factorEndianness = true) => BitConverter.ToInt32(Read(4, factorEndianness), 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining & MethodImplOptions.AggressiveOptimization)]
        private byte ReadByte() => Read(1)[0];

        private string ReadString()
        {
            var c = ReadSizeT();
            var count = (int) c;

            if (count == 0)
                return "";

            var val = Read(count, false);
            return _luaEncoding.GetString(val, 0, count - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double ReadDouble() => BitConverter.ToDouble(Read(_sizeNumber), 0);

        private Instruction DecodeInstruction(Chunk chunk)
        {
            var code = ReadInt32();
            var instruction = new Instruction(chunk, (Opcode) (code & 0x3F))
            {
                Data = code
            };

            if (_expectingSetlistData)
            {
                _expectingSetlistData = false;

                instruction.InstructionType = InstructionType.Data;
                return instruction;
            }

            instruction.A = (code >> 6) & 0xFF;

            switch (instruction.InstructionType)
            {
                //WHAT THE FUCK LUA
                case InstructionType.ABC:
                    instruction.B = (code >> 6 + 8 + 9) & 0x1FF;
                    instruction.C = (code >> 6 + 8) & 0x1FF;
                    break;

                case InstructionType.ABx:
                    instruction.B = (code >> 6 + 8) & 0x3FFFF;
                    instruction.C = -1;
                    break;

                case InstructionType.AsBx:
                    instruction.B = ((code >> 6 + 8) & 0x3FFFF) - 131071;
                    instruction.C = -1;
                    break;
            }

            if (instruction.OpCode == Opcode.SetList && instruction.C == 0)
                _expectingSetlistData = true;

            return instruction;
        }

        private List<Instruction> DecodeInstructions(Chunk chunk)
        {
            var instructions = new List<Instruction>();

            var count = ReadInt32();

            for (var i = 0; i < count; i++)
                instructions.Add(DecodeInstruction(chunk));

            return instructions;
        }

        private Constant DecodeConstant()
        {
            var constant = new Constant();
            var type = ReadByte();

            switch (type)
            {
                case 0:
                    constant.Type = ConstantType.Nil;
                    constant.Data = null!;
                    break;

                case 1:
                    constant.Type = ConstantType.Boolean;
                    constant.Data = ReadByte() != 0;
                    break;

                case 3: // have to change this btw
                    constant.Type = ConstantType.Number;
                    constant.Data = ReadDouble();
                    break;

                case 4:
                    constant.Type = ConstantType.String;
                    constant.Data = ReadString();
                    break;
            }

            return constant;
        }

        private List<Constant> DecodeConstants()
        {
            var constants = new List<Constant>();

            var count = ReadInt32();

            for (var i = 0; i < count; i++)
                constants.Add(DecodeConstant());

            return constants;
        }

        private Chunk DecodeChunk()
        {
            var chunk = new Chunk
            {
                Name = ReadString(),
                Line = ReadInt32(),
                LastLine = ReadInt32(),
                UpvalueCount = ReadByte(),
                ParameterCount = ReadByte(),
                VarargFlag = ReadByte(),
                StackSize = ReadByte(),
                Upvalues = new List<string>()
            };

            chunk.Instructions = DecodeInstructions(chunk);
            chunk.Constants = DecodeConstants();
            chunk.Functions = DecodeChunks();

            chunk.UpdateMappings();

            foreach (var inst in chunk.Instructions)
                inst.SetupRefs();

            var count = ReadInt32();
            for (var i = 0; i < count; i++) 
                chunk.Instructions[i].Line = ReadInt32();
            
            count = ReadInt32();
            for (var i = 0; i < count; i++) 
            {
                ReadString();
                ReadInt32();
                ReadInt32();
            }

            count = ReadInt32();
            for (var i = 0; i < count; i++) 
                chunk.Upvalues.Add(ReadString());

            return chunk;
        }

        private List<Chunk> DecodeChunks()
        {
            var chunks = new List<Chunk>();

            var count = ReadInt32();

            for (var i = 0; i < count; i++)
                chunks.Add(DecodeChunk());

            return chunks;
        }

        public Chunk DecodeFile()
        {
            ReadInt32(); // header
            ReadByte(); // version number
            ReadByte(); //format official shit wtf

            _bigEndian = ReadByte() == 0;

            ReadByte(); //size of int (assume 4 fuck off)

            _sizeSizeT = ReadByte();

            ReadByte(); //size of instruction (fuck it not supporting anything else than default)

            _sizeNumber = ReadByte();

            ReadByte(); //not supporting integer number bullshit fuck off
            
            return DecodeChunk();
        }
    }
}