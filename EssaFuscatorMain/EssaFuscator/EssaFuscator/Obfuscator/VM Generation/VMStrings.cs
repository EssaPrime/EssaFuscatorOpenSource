using System;

namespace EssaFuscator.Obfuscator.VM_Generation
{

	public static class VMStrings
	{
		public static string RandomString(int size)
		{
			return new String(' ', size);
		}

		public static string VMP0 => @"
local function wrapReturns(...)
    return select('#', ...), { ... };
end;
local function WrapFunction(Chunk, Environment, Upvalues)
    local Instructions = Chunk.Instructions;
    local Prototypes = Chunk.Prototypes;
    return function(...)
        local PC, Top = 1, -1;
        local Vararg, VarargSize = { }, select('#', ...) - 1;
        local Stack, ClosedUpvalues = { }, { }
        local function set_obj(index, value)
            if index > Top then
                Top = index
            end
            Stack[index] = value;
        end
        local function Dispatch()
            local Inst, Enum;
            while true do
                Inst = Instructions[PC];
                Enum = Inst.Enum;
                PC = PC + 1;
                if (Enum == 0) then -- MOVE
                    set_obj(Inst.A, Stack[Inst.B])
                elseif (Enum == 1) then -- LOADK
                    set_obj(Inst.A, Inst.B)
                elseif (Enum == 2) then -- LOADBOOL
                    set_obj(Inst.A, Inst.B ~= 0)
                    if (Inst.C ~= 0) then
                        PC = PC + 1;
                    end;
                elseif (Enum == 3) then -- LOADNIL
                    for i = Inst.A, Inst.B do
                        set_obj(i, nil)
                    end;
                elseif (Enum == 4) then -- GETUPVAL
                    set_obj(Inst.A, Upvalues[Inst.B])
                elseif (Enum == 5) then -- GETGLOBAL
                    set_obj(Inst.A, Environment[Const[Inst.B]])
                elseif (Enum == 6) then -- GETTABLE
                    set_obj(Inst.A, Stack[Inst.B][Inst.KC and Inst.C or Stack[Inst.C]])
                elseif (Enum == 7) then -- SETGLOBAL
                    Environment[Inst.B] = Stack[Inst.A];
                elseif (Enum == 8) then -- SETUPVAL
                    Upvalues[Inst.B] = Stack[Inst.A];
                elseif (Enum == 9) then -- SETTABLE
                    Stack[Inst.A][Inst.KB and Inst.B or Stack[Inst.B]] = Inst.KC and Inst.C or Stack[Inst.C]
                elseif (Enum == 10) then -- NEWTABLE
                    set_obj(Inst.A, { })
                elseif (Enum == 11) then -- SELF
                    local B = Stack[Inst.B];
                    local C = Inst.KC and Inst.C or Stack[Inst.C];
                    set_obj(Inst.A + 1, B)
                    set_obj(Inst.A, B[C])
                elseif (Enum == 12) then -- ADD
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) + (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 13) then -- SUB
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) - (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 14) then -- MUL
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) * (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 15) then -- DIV
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) / (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 16) then -- MOD
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) % (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 17) then -- POW
                    set_obj(Inst.A, (Inst.KB and Inst.B or Stack[Inst.B]) ^ (Inst.KC and Inst.C or Stack[Inst.C]))
                elseif (Enum == 18) then -- UNM
                    set_obj(Inst.A, -Stack[Inst.B])
                elseif (Enum == 19) then -- NOT
                    set_obj(Inst.A, not Stack[Inst.B])
                elseif (Enum == 20) then -- LEN
                    set_obj(Inst.A, #Stack[Inst.B])
                elseif (Enum == 21) then -- CONCAT
                    local B = Inst.B;
                    local K = Stack[B];
                    for i = B + 1, Inst.C do
                        K = K .. Stack[i];
                    end;
                    set_obj(Inst.A, K)
                elseif (Enum == 22) then -- JMP
                    PC = PC + Inst.B;
                elseif (Enum == 23) then -- EQ
                    local B = Inst.KB and Inst.B or Stack[Inst.B];
                    local C = Inst.KC and Inst.C or Stack[Inst.C];
                    if (B == C) ~= Inst.A then
                        PC = PC + 1;
                    end;
                elseif (Enum == 24) then -- LT
                    local B = Inst.KB and Inst.B or Stack[Inst.B];
                    local C = Inst.KC and Inst.C or Stack[Inst.C];
                    if (B < C) ~= Inst.A then
                        PC = PC + 1;
                    end;
                elseif (Enum == 25) then -- LE
                    local B = Inst.KB and Inst.B or Stack[Inst.B];
                    local C = Inst.KC and Inst.C or Stack[Inst.C];
                    if (B <= C) ~= Inst.A then
                        PC = PC + 1;
                    end;
                elseif (Enum == 26) then -- TEST
                    if Inst.C then
                        if Stack[Inst.A] then
                            PC = PC + 1;
                        end
                    elseif Stack[Inst.A] then
                    else
                        PC = PC + 1;
                    end
                elseif (Enum == 27) then -- TESTSET
                    local B = Stack[Inst.B];
                    if Inst.C then
                        if B then
                            PC = PC + 1;
                        else
                            set_obj(Inst.A, B)
                        end
                    elseif B then
                        set_obj(Inst.A, B)
                    else
                        PC = PC + 1;
                    end
                elseif (Enum == 28) then -- CALL
                    local A = Inst.A;
                    local B = Inst.B;
                    local C = Inst.C;
                    local Args, Results;
                    local Limit, Edx;
                    Args = { };
                    if (B ~= 1) then
                        if (B ~= 0) then
                            Limit = A + B - 1;
                        else
                            Limit = Top;
                        end;
                        Edx = 0;
                        for i = A + 1, Limit do
                            Edx = Edx + 1;
                            Args[Edx] = Stack[i];
                        end;
                        Limit, Results = wrapReturns(Stack[A](table.unpack(Args, 1, Limit - A)));
                    else
                        Limit, Results = wrapReturns(Stack[A]());
                    end;
                    Top = A - 1;
                    if (C ~= 1) then
                        if (C ~= 0) then
                            Limit = A + C - 2;
                        else
                            Limit = Limit + A - 1;
                        end;
                        Edx = 0;
                        for i = A, Limit do
                            Edx = Edx + 1;
                            set_obj(i, Results[Edx])
                        end;
                    end;
                elseif (Enum == 29) then -- TAILCALL
                    local A = Inst.A;
                    local B = Inst.B;
                    local Args, Results;
                    local Limit;
                    local Rets = 0;
                    Args = { };
                    if (B ~= 1) then
                        if (B ~= 0) then
                            Limit = A + B - 1;
                        else
                            Limit = Top;
                        end
                        for i = A + 1, Limit do
                            Args[#Args + 1] = Stack[i];
                        end
                        Results = { Stack[A](table.unpack(Args, 1, Limit - A)) };
                    else
                        Results = { Stack[A]() };
                    end;
                    for Index in pairs(Results) do -- get return count
                        if (Index > Rets) then
                            Rets = Index;
                        end;
                    end;
                    return Results, Rets;
                elseif (Enum == 30) then -- RETURN
                    local A = Inst.A;
                    local B = Inst.B;
                    local Edx, Output;
                    local Limit;
                    if (B == 1) then
                        return;
                    elseif (B == 0) then
                        Limit = Top;
                    else
                        Limit = A + B - 2;
                    end;
                    Output = { };
                    Edx = 0;
                    for i = A, Limit do
                        Edx = Edx + 1;
                        Output[Edx] = Stack[i];
                    end;
                    return Output, Edx;
                elseif (Enum == 31) then -- FORLOOP
                    local Step = Stack[Inst.A + 2];
                    local Index = Stack[Inst.A] + Step;
                    set_obj(Inst.A, Index)
                    if (Step > 0) then
                        if Index <= Stack[Inst.A + 1] then
                            PC = PC + Inst.B;
                            set_obj(Inst.A + 3, Index)
                        end;
                    else
                        if Index >= Stack[Inst.A + 1] then
                            PC = PC + Inst.B;
                            set_obj(Inst.A + 3, Index)
                        end
                    end
                elseif (Enum == 32) then -- FORPREP
                    set_obj(Inst.A, assert(tonumber(Stack[Inst.A]), 'Essafuscator: Fatal VM Error | Please contact EssaPrime'))
                    set_obj(Inst.A + 1, assert(tonumber(Stack[Inst.A + 1]), 'Essafuscator: Fatal VM Error | Please contact EssaPrime'))
                    set_obj(Inst.A + 2, assert(tonumber(Stack[Inst.A + 2]), 'Essafuscator: Fatal VM Error | Please contact EssaPrime'))
                    set_obj(Inst.A, Stack[Inst.A] - Stack[Inst.A + 2])
                    PC = PC + Inst.B;
                elseif (Enum == 33) then -- TFORLOOP
                    local Offset = Inst.A + 2;
                    local Result = { Stack[Inst.A](Stack[Inst.A + 1], Stack[Inst.A + 2]) };
                    for i = 1, Inst.C do
                        set_obj(Offset + 1, Result[i])
                    end;
                    if (Stack[Inst.A + 3] ~= nil) then
                        set_obj(Inst.A + 2, Stack[Inst.A + 3])
                    else
                        PC = PC + 1;
                    end;
                elseif (Enum == 34) then -- SETLIST
                    if (Inst.C == 0) then
                        PC = PC + 1;
                        Inst.C = Instr[PC].Value;
                    end;
                    local Offset = (Inst.C - 1) * 50;
                    local T = Stack[Inst.A]; 
                    if (Inst.B == 0) then
                        Inst.B = Top - Inst.A;
                    end;
                    for i = 1, Inst.B do
                        T[Offset + i] = Stack[Inst.A + i];
                    end;
                elseif (Enum == 35) then -- CLOSE
                    local Cls = { }; 
                    for i = 1, #ClosedUpvalues do
                        local List = ClosedUpvalues[i];
                        for Idz = 0, #List do
                            local Upv = List[Idz];
                            local Stk = Upv[1];
                            local Pos = Upv[2];
                            if (Stack == Stk) and (Pos >= Inst.A) then
                                Cls[Pos] = Stk[Pos];
                                Upv[1] = Cls;
                            end;
                        end;
                    end;
                elseif (Enum == 36) then -- CLOSURE
                    local NewProto = Prototypes[Inst.B];
                    local Indexes;
                    local NewUvals;
                    if (NewProto.Nupvals ~= 0) then
                        Indexes = { };
                        NewUvals = setmetatable({ }, {
                            __index = function(_, Key)
                                local Val = Indexes[Key];
                                return Val[1][Val[2]];
                            end,
                            __newindex = function(_, Key, Value)
                                local Val = Indexes[Key];
                                Val[1][Val[2]] = Value;
                            end;
                        });
                        for i = 1, NewProto.Nupvals do
                            local Mvm = Instructions[PC];
                            if (Mvm.Enum == 0) then -- MOVE
                                Indexes[i - 1] = {
                                    Stack,
                                    Mvm[2]
                                };
                            elseif (Mvm.Enum == 4) then -- GETUPVAL
                                Indexes[i - 1] = {
                                    Upvalues,
                                    Mvm[2]
                                };
                            end;
                            PC = PC + 1;
                        end;
                        ClosedUpvalues[#ClosedUpvalues + 1] = Indexes;
                    end;
                    set_obj(Inst.A, WrapFunction(NewProto, Environment, NewUvals))
                elseif (Enum == 37) then -- VARARG
                    Top = Inst.A - 1;
                    for i = Inst.A, Inst.A + (Inst.B > 0 and Inst.B - 1 or VarargSize) do
                        set_obj(i, Vararg[i - Inst.A])
                    end;
                end;
            end;
        end;

        local Args = { ... };
        for i = 0, VarargSize do
            Vararg[i] = Args[i + 1];
        end;

        local A, B, C = pcall(Dispatch); -- Pcalling to allow yielding
        if A then -- We're always expecting this to come out true (because errorless code)
            if B and (C > 0) then -- So I flipped the conditions.
                return table.unpack(B, 1, C);
            end;
            return;
        else
            error('Essafuscator: Fatal VM Error | Please contact EssaPrime')
        end;
    end;
end;


-- WRAPPER ABOVE
";

		public static string VMP1(int xorkey, bool hasAntiTamper) => $@"
local function EssaPrimeBitCreator(Bit, Start, End)
	if End then
		local Res = (Bit / 0x2 ^ (Start - 0x1)) % 0x2 ^ ((End - 0x1) - (Start - 0x1) + 0x1);
		return Res - Res % 0x1;
	else
		local Plc = 0x2 ^ (Start - 0x1);
        return (Bit % (Plc + Plc) >= Plc) and 0x1 or 0x0;
	end;
end;

local function BXOR(a, b, c, ...)
  local z
  if b then
    a = a % MOD
    b = b % MOD
    z = bxor(a, b)
    if c then
      z = BXOR(z, c, ...)
    end
    return z
  elseif a then
    return a % MOD
  else
    return 0
  end
end

local function BAND(a, b, c, ...)
  local z
  if b then
    a = a % MOD
    b = b % MOD
    z = ((a+b) - BXOR(a,b)) / 2
    if c then
      z = BAND(z, c, ...)
    end
    return z
  elseif a then
    return a % MOD
  else
    return MODM
  end
end

local function BOR(a, b, c, ...)
  local z
  if b then
    a = a % MOD
    b = b % MOD
    z = MODM - BAND(MODM - a, MODM - b)
    if c then
      z = BOR(z, c, ...)
    end
    return z
  elseif a then
    return a % MOD
  else
    return 0
  end
end

local function LSHIFT(x,disp)
  if disp > 31 or disp < -31 then return 0 end
  return LSHIFT(x % MOD, disp)
end

local function RSHIFT(x,disp)
  if disp > 31 or disp < -31 then return 0 end
  return RSHIFT(x % MOD, disp)
end

local XOR_KEY = ({AdvancedCFGenerator.NumberGenerator.ConfuseNumber(xorkey)});

local Pos = #(""{RandomString(1)}"");

local _32768 = ({AdvancedCFGenerator.NumberGenerator.ConfuseNumber(32768)});
local function Essa32Bits()
    local W, X, Y, Z = EssaPrimeBite(WasHere, Pos, Pos + #(""{RandomString(3)}""));
	W = (W ~ XOR_KEY)
	X = (X ~ XOR_KEY)
	Y = (Y ~ XOR_KEY)
	Z = (Z ~ XOR_KEY)
    Pos	= Pos + #(""{RandomString(4)}"");
    return (Z*_32768* 0x200) + (Y*_32768*2) + (X*0x100) + W;
end;
local function Essa8Bits()
    local F = (EssaPrimeBite(WasHere, Pos, Pos)~  XOR_KEY);
    Pos = Pos + #(""{RandomString(1)}"");
    return F;
end;
local function EssaPrimeWater()
	local Left = Essa32Bits();
	local Right = Essa32Bits();
	local IsNormal = #(""{RandomString(1)}"");
	local Mantissa = (EssaPrimeBitCreator(Right, 0x1, 0x14) * ( 0x2 ^ 0x20))
					+ Left;
	local Exponent = EssaPrimeBitCreator(Right, 0x15, 0x1F);
	local Sign = ((-1) ^ EssaPrimeBitCreator(Right, 0x20));
	if (Exponent == #("""")) then
		if (Mantissa == #("""")) then
			return Sign * #(""""); -- +-#("""")
		else
			Exponent = #(""{RandomString(1)}"");
			IsNormal = #("""");
		end;
	elseif (Exponent == (_32768/16-1)) then
        return (Mantissa == #("""")) and (Sign * (#(""{RandomString(1)}"") / #(""""))) or (Sign * (#("""") / #("""")));
	end;
	return LDExp(Sign, Exponent - (_32768/32-1)) * (IsNormal + (Mantissa / (0x2 ^ 0x34)));
end;


local gSizet = Essa32Bits;
local function EssaPrimeStrings(Len)
    local Str;
    if (not Len) then
        Len = gSizet();
        if (Len == #("""")) then
            return '';
        end;
    end;

    Str	= EssaPrimeSubmarine(WasHere, Pos, Pos + Len - #(""{RandomString(1)}""));
    Pos = Pos + Len;

	local FStr = {{}}
	for Idx = #(""{RandomString(1)}""), #Str do
		FStr[Idx] = EssaPrimeCharcoal(EssaPrimeBite(EssaPrimeSubmarine(Str, Idx, Idx)) ~ XOR_KEY)
	end

    local new = """" for i=#(""{RandomString(1)}""),#FStr do new = new..FStr[i] end return new
end;

local gInt = Essa32Bits;
local function _R(...) return {{...}}, Select('#', ...) end

local function EssaDeserlizer()
    local Instrs = {{ INSTR_CNT }};
    local Functions = {{ FUNC_CNT }};
	local Lines = {{}};
    local Chunk = 
	{{
		Instrs,
		nil,
		Functions,
		nil,
		Lines
	}};";
		
		public static string VMP2 = $@"
local function EssaSubway(Chunk, Upvalues, Env)
	local Instr  = Chunk[#(""{RandomString(1)}"")];
	local Const  = Chunk[#(""{RandomString(2)}"")];
	local Proto  = Chunk[#(""{RandomString(3)}"")];
	local Params = Chunk[#(""{RandomString(4)}"")];

	return function(...)
		local Instr  = Instr; 
		local Const  = Const; 
		local Proto  = Proto; 
		local Params = Params;

		local _R = _R
		local InstrPoint = #(""{RandomString(1)}"");
		local Top = -#(""{RandomString(1)}"");

		local Vararg = {{}};
		local Args	= {{...}};

		local PCount = Select('#', ...) - #(""{RandomString(1)}"");

		local Lupvals	= {{}};
		local Stk		= {{}};

		for Idx = #(""""), PCount do
			if (Idx >= Params) then
				Vararg[Idx - Params] = Args[Idx + #(""{RandomString(1)}"")];
			else
				Stk[Idx] = Args[Idx + #(""{RandomString(1)}"")];
			end;
		end;

		local Varargsz = PCount - Params + #(""{RandomString(1)}"")

		local Inst;
		local Enum;	

		while true do
			Inst		= Instr[InstrPoint];
			Enum		= Inst[OP_ENUM];";

		public static string VMP3 = $@"
			InstrPoint	= InstrPoint + #(""{RandomString(1)}"");
		end;
    end;
end;	
return EssaSubway(EssaDeserlizer(), {{}}, GetFEnv())();
";
        
		public static string VMP2_LI = $@"
local PCall = pcall
local coolfeenv = function() return _ENV end
local function EssaSubway(Chunk, Upvalues, Env)
	local Instr = Chunk[#(""{RandomString(1)}"")];
	local Const = Chunk[#(""{RandomString(2)}"")];
	local Proto = Chunk[#(""{RandomString(3)}"")];
	local Params = Chunk[#(""{RandomString(4)}"")];

	return function(...)
		local InstrPoint = #(""{RandomString(1)}"");
		local Top = -#(""{RandomString(1)}"");

		local Args = {{...}};
		local PCount = Select('#', ...) - #(""{RandomString(1)}"");

		local function Loop()
			local Instr  = Instr; 
			local Const  = Const; 
			local Proto  = Proto; 
			local Params = Params;

			local _R = _R
			local Vararg = {{}};

			local Lupvals	= {{}};
			local Stk		= {{}};
	
			for Idx = #(""""), PCount do
				if (Idx >= Params) then
					Vararg[Idx - Params] = Args[Idx + #(""{RandomString(1)}"")];
				else
					Stk[Idx] = Args[Idx + #(""{RandomString(1)}"")];
				end;
			end;
	
			local Varargsz = PCount - Params + #(""{RandomString(1)}"")

			local Inst;
			local Enum;	

			while true do
				Inst		= Instr[InstrPoint];
				Enum		= Inst[OP_ENUM];";
		
		//public static string VMP3_LI = ;
	}
}