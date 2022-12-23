local __Select__ = select
local __Wrap__ = coroutine.wrap
local fJVmEp = (function(__Select__, __Wrap__, EssaPrimeBite, EssaPrimeCharcoal, EssaPrimeSubmarine, Concat, LDExp, Setmetatable, Select, Unpack, ToNumber, Reverser, DaddyPrimeIsEssaPrimeSTRINGG)
    local function EssaFlipMe(t)
        local tt = { }
        for i, v in pairs(t) do
            tt[v] = i
        end
        return tt
    end
    local EssaPrimePaint = {
        EssaPrimeCharcoal(0x42),
        EssaPrimeCharcoal(0x43),
        EssaPrimeCharcoal(0x44),
        EssaPrimeCharcoal(0x45),
        EssaPrimeCharcoal(0x46),
        EssaPrimeCharcoal(0x47),
        EssaPrimeCharcoal(0x48),
        EssaPrimeCharcoal(0x49),
        EssaPrimeCharcoal(0x4A),
        EssaPrimeCharcoal(0x4B),
        EssaPrimeCharcoal(0x4C),
        EssaPrimeCharcoal(0x4D),
        EssaPrimeCharcoal(0x4E),
        EssaPrimeCharcoal(0x4F),
        EssaPrimeCharcoal(0x50),
        EssaPrimeCharcoal(0x51),
        EssaPrimeCharcoal(0x52),
        EssaPrimeCharcoal(0x53),
        EssaPrimeCharcoal(0x54),
        EssaPrimeCharcoal(0x55),
        EssaPrimeCharcoal(0x56),
        EssaPrimeCharcoal(0x57),
        EssaPrimeCharcoal(0x58),
        EssaPrimeCharcoal(0x59),
        EssaPrimeCharcoal(0x5A),
        EssaPrimeCharcoal(0x61),
        EssaPrimeCharcoal(0x62),
        EssaPrimeCharcoal(0x63),
        EssaPrimeCharcoal(0x64),
        EssaPrimeCharcoal(0x65),
        EssaPrimeCharcoal(0x66),
        EssaPrimeCharcoal(0x67),
        EssaPrimeCharcoal(0x68),
        EssaPrimeCharcoal(0x69),
        EssaPrimeCharcoal(0x6A),
        EssaPrimeCharcoal(0x6B),
        EssaPrimeCharcoal(0x6C),
        EssaPrimeCharcoal(0x6D),
        EssaPrimeCharcoal(0x6E),
        EssaPrimeCharcoal(0x6F),
        EssaPrimeCharcoal(0x70),
        EssaPrimeCharcoal(0x71),
        EssaPrimeCharcoal(0x72),
        EssaPrimeCharcoal(0x73),
        EssaPrimeCharcoal(0x74),
        EssaPrimeCharcoal(0x75),
        EssaPrimeCharcoal(0x76),
        EssaPrimeCharcoal(0x77),
        EssaPrimeCharcoal(0x78),
        EssaPrimeCharcoal(0x79),
        EssaPrimeCharcoal(0x7A),
        EssaPrimeCharcoal(0x30),
        EssaPrimeCharcoal(0x31),
        EssaPrimeCharcoal(0x32),
        EssaPrimeCharcoal(0x33),
        EssaPrimeCharcoal(0x34),
        EssaPrimeCharcoal(0x35),
        EssaPrimeCharcoal(0x36),
        EssaPrimeCharcoal(0x37),
        EssaPrimeCharcoal(0x38),
        EssaPrimeCharcoal(0x39),
        EssaPrimeCharcoal(0x21),
        EssaPrimeCharcoal(0x23),
        EssaPrimeCharcoal(0x24),
        EssaPrimeCharcoal(0x25),
        EssaPrimeCharcoal(0x26),
        EssaPrimeCharcoal(0x28),
        EssaPrimeCharcoal(0x29),
        EssaPrimeCharcoal(0x2A),
        EssaPrimeCharcoal(0x2B),
        EssaPrimeCharcoal(0x2C),
        EssaPrimeCharcoal(0x2E),
        EssaPrimeCharcoal(0x2F),
        EssaPrimeCharcoal(0x3A),
        EssaPrimeCharcoal(0x3B),
        EssaPrimeCharcoal(0x3C),
        EssaPrimeCharcoal(0x3D),
        EssaPrimeCharcoal(0x3E),
        EssaPrimeCharcoal(0x3F),
        EssaPrimeCharcoal(0x40),
        EssaPrimeCharcoal(0x5B),
        EssaPrimeCharcoal(0x5D),
        EssaPrimeCharcoal(0x5E),
        EssaPrimeCharcoal(0x5F),
        EssaPrimeCharcoal(0x60),
        EssaPrimeCharcoal(0x7B),
        EssaPrimeCharcoal(0x7C),
        EssaPrimeCharcoal(0x7D),
        EssaPrimeCharcoal(0x7E),
        EssaPrimeCharcoal(0x22)
    }
    EssaPrimePaint[0] = EssaPrimeCharcoal(65)
    local EssaPrimeCoating = EssaFlipMe(EssaPrimePaint)
    local function DaddyPrime(b)
        local c, d, e, f, g = #b, -1, '', 0, 0
        for h in b:gmatch('.') do
            local i = EssaPrimeCoating[h]
            if not i then
            else
                if d < 0 then
                    d = i
                else
                    d = d + i * 91
                    f = f | (d << g)
                    if d & 8191 then
                        g = g + 13
                    else
                        g = g + 14
                    end
                    while true do
                        e = e .. EssaPrimeCharcoal(f & 255)
                        f = f >> 8
                        g = g - 8
                        if not(g > 7) then
                            break
                        end
                    end
                    d = -1
                end
            end
        end
        if d + 1 > 0 then
            e = e .. string.char((f | (d << g) & 255))
        end
        local b = Reverser(e)
        local i, j, k = '', '', { }
        local l = 256
        local m = { }
        for n = 0, l - 1 do
            m[n] = EssaPrimeCharcoal(n)
        end
        local h = 1
        local function o()
            local c = ToNumber(EssaPrimeSubmarine(b, h, h), 36)
            h = h + 1
            local p = ToNumber(EssaPrimeSubmarine(b, h, h + c - 1), 36)
            h = h + c
            return p
        end
        i = EssaPrimeCharcoal(o())
        k[1] = i
        while h < #b do
            local g = o()
            if m[g] then
                j = m[g]
            else
                j = i .. EssaPrimeSubmarine(i, 1, 1)
            end
            m[l] = i .. EssaPrimeSubmarine(j, 1, 1)
            k[#k + 1], i, l = j, j, l + 1
        end
        return Concat(k)
    end
    local WasHere = DaddyPrime(DaddyPrimeIsEssaPrimeSTRINGG)
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
    local function EssaPrimeBitCreator(Bit, Start, End)
        if End then
            local Res = (Bit / 0x2 ^ (Start - 0x1)) % 0x2 ^ ((End - 0x1) - (Start - 0x1) + 0x1);
            return Res - Res % 0x1;
        else
            local Plc = 0x2 ^ (Start - 0x1);
            return(Bit % (Plc + Plc) >= Plc) and 0x1 or 0x0;
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
            z = ((a + b) - BXOR(a, b)) / 2
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
    local function LSHIFT(x, disp)
        if disp > 31 or disp < -31 then
            return 0
        end
        return LSHIFT(x % MOD, disp)
    end
    local function RSHIFT(x, disp)
        if disp > 31 or disp < -31 then
            return 0
        end
        return RSHIFT(x % MOD, disp)
    end
    local XOR_KEY = ((-25324 + (function()
        local recurses, num = 0, 1;
        (function(fArg0)
            fArg0(fArg0(fArg0))
        end)(function(fArg0)
            if recurses > 381 then
                return fArg0
            end
            recurses = recurses + 1
            num = (num - 194) % 26205
            if (num % 1792) <= 896 then
                return fArg0
            else
                return fArg0(fArg0(fArg0))
            end
            return fArg0(fArg0(fArg0))
        end)
        return num;
    end)()));
    local Pos = #(" ");
    local _32768 = ((29336 + (function()
        local recurses, num = 0, 1;
        (function(fArg0, fArg1)
            fArg0(fArg0(fArg0, fArg0), fArg1(fArg0, fArg1) and fArg1(fArg0, fArg0))
        end)(function(fArg0, fArg1)
            if recurses > 375 then
                return fArg1
            end
            recurses = recurses + 1
            num = (num * 110) % 3478
            if (num % 1198) <= 599 then
                return fArg1
            else
                return fArg1(fArg0(fArg1, fArg1), fArg1(fArg1, fArg1))
            end
            return fArg0(fArg1(fArg1, fArg0), fArg0(fArg1, fArg1))
        end, function(fArg1, fArg0)
            if recurses > 400 then
                return fArg1
            end
            recurses = recurses + 1
            num = (num - 681) % 26828
            if (num % 742) < 371 then
                return fArg0
            else
                return fArg1(fArg0(fArg0, fArg0), fArg0(fArg1, fArg0) and fArg0(fArg1, fArg0))
            end
            return fArg0(fArg1(fArg1, fArg1 and fArg1), fArg0(fArg1, fArg1 and fArg0))
        end)
        return num;
    end)()));
    local function Essa32Bits()
        local W, X, Y, Z = EssaPrimeBite(WasHere, Pos, Pos + #("   "));
        W = (W ~ XOR_KEY)
        X = (X ~ XOR_KEY)
        Y = (Y ~ XOR_KEY)
        Z = (Z ~ XOR_KEY)
        Pos = Pos + #("    ");
        return(Z * _32768 * 0x200) + (Y * _32768 * 2) + (X * 0x100) + W;
    end;
    local function Essa8Bits()
        local F = (EssaPrimeBite(WasHere, Pos, Pos) ~ XOR_KEY);
        Pos = Pos + #(" ");
        return F;
    end;
    local function EssaPrimeWater()
        local Left = Essa32Bits();
        local Right = Essa32Bits();
        local IsNormal = #(" ");
        local Mantissa = (EssaPrimeBitCreator(Right, 0x1, 0x14) * (0x2 ^ 0x20)) + Left;
        local Exponent = EssaPrimeBitCreator(Right, 0x15, 0x1F);
        local Sign = ((-1) ^ EssaPrimeBitCreator(Right, 0x20));
        if (Exponent == #("")) then
            if (Mantissa == #("")) then
                return Sign * #(""); -- +-#("")
            else
                Exponent = #(" ");
                IsNormal = #("");
            end;
        elseif (Exponent == (_32768 / 16 - 1)) then
            return(Mantissa == #("")) and (Sign * (#(" ") / #(""))) or (Sign * (#("") / #("")));
        end;
        return LDExp(Sign, Exponent - (_32768 / 32 - 1)) * (IsNormal + (Mantissa / (0x2 ^ 0x34)));
    end;
    local gSizet = Essa32Bits;
    local function EssaPrimeStrings(Len)
        local Str;
        if (not Len) then
            Len = gSizet();
            if (Len == #("")) then
                return '';
            end;
        end;
        Str = EssaPrimeSubmarine(WasHere, Pos, Pos + Len - #(" "));
        Pos = Pos + Len;
        local FStr = { }
        for Idx = #(" "), #Str do
            FStr[Idx] = EssaPrimeCharcoal(EssaPrimeBite(EssaPrimeSubmarine(Str, Idx, Idx)) ~ XOR_KEY)
        end
        local new = ""
        for i = #(" "), #FStr do
            new = new .. FStr[i]
        end
        return new
    end;
    local gInt = Essa32Bits;
    local function _R(...)
        return { ... }, Select('#', ...)
    end
    local function EssaDeserlizer()
        local Instrs = { };
        local Functions = {
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        };
        local Lines = { };
        local Chunk = {
            Instrs,
            nil,
            Functions,
            nil,
            Lines
        };
        for Idx = 1, Essa32Bits() do
            Lines[Idx] = Essa32Bits();
        end;
        for Idx = 1, Essa32Bits() do
            Functions[Idx - 1] = EssaDeserlizer();
        end;
        Chunk[4] = Essa8Bits();
        local ConstCount = Essa32Bits()
        local Consts = { };
        for Idx = 1, ConstCount do
            local Type = Essa8Bits();
            local Cons;
            if (Type == 3) then
                Cons = (Essa8Bits() ~= 0);
            elseif (Type == 0) then
                Cons = EssaPrimeWater(EssaPrimeBitCreator, Essa32Bits);
            elseif (Type == 2) then
                Cons = EssaPrimeStrings();
            end;
            Consts[Idx] = Cons;
        end;
        Chunk[2] = Consts
        for Idx = 1, Essa32Bits() do
            local Data1 = (Essa32Bits() ~ 126);
            local Data2 = (Essa32Bits() ~ 97);
            local Type = EssaPrimeBitCreator(Data1, 1, 2);
            local Opco = EssaPrimeBitCreator(Data2, 1, 11);
            local Inst = {
                Opco,
                EssaPrimeBitCreator(Data1, 3, 11),
                nil,
                nil,
                Data2
            };
            if (Type == 0) then
                Inst[3] = EssaPrimeBitCreator(Data1, 12, 20);
                Inst[5] = EssaPrimeBitCreator(Data1, 21, 29);
            elseif (Type == 1) then
                Inst[3] = EssaPrimeBitCreator(Data2, 12, 33);
            elseif (Type == 2) then
                Inst[3] = EssaPrimeBitCreator(Data2, 12, 32) - 1048575;
            elseif (Type == 3) then
                Inst[3] = EssaPrimeBitCreator(Data2, 12, 32) - 1048575;
                Inst[5] = EssaPrimeBitCreator(Data1, 21, 29);
            end;
            Instrs[Idx] = Inst;
        end;
        return Chunk;
    end;
    local PCall = pcall
    local coolfeenv = function()
        return _ENV
    end
    local function EssaSubway(Chunk, Upvalues, Env)
        local Instr = Chunk[#(" ")];
        local Const = Chunk[#("  ")];
        local Proto = Chunk[#("   ")];
        local Params = Chunk[#("    ")];
        return function(...)
            local InstrPoint = #(" ");
            local Top = -#(" ");
            local Args = { ... };
            local PCount = Select('#', ...) - #(" ");
            local function Loop()
                local Instr = Instr;
                local Const = Const;
                local Proto = Proto;
                local Params = Params;
                local _R = _R
                local Vararg = { };
                local Lupvals = { };
                local Stk = { };
                for Idx = #(""), PCount do
                    if (Idx >= Params) then
                        Vararg[Idx - Params] = Args[Idx + #(" ")];
                    else
                        Stk[Idx] = Args[Idx + #(" ")];
                    end;
                end;
                local Varargsz = PCount - Params + #(" ")
                local Inst;
                local Enum;
                while true do
                    Inst = Instr[InstrPoint];
                    Enum = Inst[1];
                    if Enum <= 26 then
                        if 12 >= Enum then
                            if Enum <= 5 then
                                if Enum < 3 then
                                    if Enum > 0 then
                                        if 1 ~= Enum then
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        else
                                            local A = Inst[2];
                                            local Results, Limit = { Stk[A]() };
                                            local Limit = A + Inst[5] - 2;
                                            local Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                        end
                                    else
                                        local A = Inst[2];
                                        local B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                    end
                                else
                                    if Enum >= 4 then
                                        if Enum >= 3 then
                                            if 4 ~= Enum then
                                                local A = Inst[2];
                                                local Args = { };
                                                local Edx = 0;
                                                local Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                local Results, Limit = _R(Stk[A](Unpack(Args, 1, Limit - A)));
                                                Limit = Limit + A - 1;
                                                Edx = 0;
                                                for Idx = A, Limit do
                                                    Edx = Edx + 1;
                                                    Stk[Idx] = Results[Edx];
                                                end;
                                                Top = Limit;
                                                goto VjjfYuro;
                                            end;
                                            do
                                                return
                                            end;
                                            ::VjjfYuro::
                                        else
                                            do
                                                return
                                            end;
                                        end
                                    else
                                        Stk[Inst[2]] = (Inst[3] ~= 0);
                                    end
                                end
                            else
                                if 8 >= Enum then
                                    if Enum > 6 then
                                        if Enum > 6 then
                                            if Enum > 7 then
                                                local A = Inst[2];
                                                local Args = { };
                                                local Edx = 0;
                                                local Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                local Results, Limit = _R(Stk[A](Unpack(Args, 1, Limit - A)));
                                                Limit = Limit + A - 1;
                                                Edx = 0;
                                                for Idx = A, Limit do
                                                    Edx = Edx + 1;
                                                    Stk[Idx] = Results[Edx];
                                                end;
                                                Top = Limit;
                                                goto uWzAkeJE;
                                            end;
                                            local A = Inst[2];
                                            local Limit = A + Inst[3] - 2;
                                            local Output = { };
                                            local Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Output[Edx] = Stk[Idx];
                                            end;
                                            do
                                                return Unpack(Output, 1, Edx)
                                            end;
                                            ::uWzAkeJE::
                                        else
                                            local A = Inst[2];
                                            local Limit = A + Inst[3] - 2;
                                            local Output = { };
                                            local Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Output[Edx] = Stk[Idx];
                                            end;
                                            do
                                                return Unpack(Output, 1, Edx)
                                            end;
                                        end
                                    else
                                        local B;
                                        local Limit;
                                        local Edx;
                                        local Args;
                                        local A;
                                        Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Stk[A](Unpack(Args, 1, Limit - A));
                                        Top = A;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = { };
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                    end
                                else
                                    if Enum > 10 then
                                        if 12 == Enum then
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        else
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    else
                                        if 6 < Enum then
                                            if Enum ~= 9 then
                                                local B;
                                                local Limit;
                                                local Edx;
                                                local Args;
                                                local A;
                                                Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = { };
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                                goto aCW_srfi;
                                            end;
                                            Stk[Inst[2]] = { };
                                            ::aCW_srfi::
                                        else
                                            Stk[Inst[2]] = { };
                                        end
                                    end
                                end
                            end
                        else
                            if Enum < 20 then
                                if 15 >= Enum then
                                    if 13 >= Enum then
                                        local A = Inst[2];
                                        local Args = { };
                                        local Edx = 0;
                                        local Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        local Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                        local Limit = A + Inst[5] - 2;
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Stk[Idx] = Results[Edx];
                                        end;
                                        Top = Limit;
                                    else
                                        if Enum >= 11 then
                                            if Enum ~= 14 then
                                                local Results;
                                                local Limit;
                                                local Edx;
                                                local Args;
                                                local B;
                                                local A;
                                                Stk[Inst[2]] = Env[Const[Inst[3]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                                Limit = A + Inst[5] - 2;
                                                Edx = 0;
                                                for Idx = A, Limit do
                                                    Edx = Edx + 1;
                                                    Stk[Idx] = Results[Edx];
                                                end;
                                                Top = Limit;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                do
                                                    return
                                                end;
                                                goto wUBytUKA;
                                            end;
                                            local A = Inst[2];
                                            local Args = { };
                                            local Edx = 0;
                                            local Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            local Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            local Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            ::wUBytUKA::
                                        else
                                            local Results;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            do
                                                return
                                            end;
                                        end
                                    end
                                else
                                    if Enum < 18 then
                                        if Enum >= 12 then
                                            if Enum ~= 16 then
                                                Stk[Inst[2]] = EssaSubway(Proto[Inst[3]], nil, Env);
                                                goto rOYRjRLX;
                                            end;
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            ::rOYRjRLX::
                                        else
                                            Stk[Inst[2]] = Const[Inst[3]];
                                        end
                                    else
                                        if 18 ~= Enum then
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                        else
                                            local Results;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            do
                                                return
                                            end;
                                        end
                                    end
                                end
                            else
                                if 23 > Enum then
                                    if Enum > 20 then
                                        if 22 ~= Enum then
                                            local A = Inst[2];
                                            local B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                        else
                                            Stk[Inst[2]] = EssaSubway(Proto[Inst[3]], nil, Env);
                                        end
                                    else
                                        local Output;
                                        local Limit;
                                        local Edx;
                                        local Args;
                                        local A;
                                        Stk[Inst[2]] = Env[Const[Inst[3]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = (Inst[3] ~= 0);
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Stk[A](Unpack(Args, 1, Limit - A));
                                        Top = A;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]] | Const[Inst[5]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Limit = A + Inst[3] - 2;
                                        Output = { };
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Output[Edx] = Stk[Idx];
                                        end;
                                        do
                                            return Unpack(Output, 1, Edx)
                                        end;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        do
                                            return
                                        end;
                                    end
                                else
                                    if Enum > 24 then
                                        if 21 ~= Enum then
                                            if Enum ~= 26 then
                                                local B;
                                                local Limit;
                                                local Edx;
                                                local Args;
                                                local A;
                                                Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = { };
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                                goto LwrtOVmg;
                                            end
                                            Stk[Inst[2]] = Stk[Inst[3]] | Const[Inst[5]];
                                            ::LwrtOVmg::
                                        else
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    else
                                        if 24 == Enum then
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                        else
                                            local Results;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            do
                                                return
                                            end;
                                        end
                                    end
                                end
                            end
                        end
                    else
                        if Enum < 40 then
                            if Enum < 33 then
                                if 29 < Enum then
                                    if 30 < Enum then
                                        if 32 > Enum then
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        else
                                            local A = Inst[2];
                                            local Limit = A + Inst[3] - 2;
                                            local Output = { };
                                            local Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Output[Edx] = Stk[Idx];
                                            end;
                                            do
                                                return Unpack(Output, 1, Edx)
                                            end;
                                        end
                                    else
                                        Stk[Inst[2]] = Env[Const[Inst[3]]];
                                    end
                                else
                                    if 27 >= Enum then
                                        local A = Inst[2];
                                        local Args = { };
                                        local Edx = 0;
                                        local Limit = Top;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        local Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                        local Limit = A + Inst[5] - 2;
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Stk[Idx] = Results[Edx];
                                        end;
                                        Top = Limit;
                                    else
                                        if 26 <= Enum then
                                            if Enum < 29 then
                                                local A = Inst[2];
                                                local Args = { };
                                                local Edx = 0;
                                                local Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                goto hgukWcuD;
                                            end
                                            local A = Inst[2];
                                            local Results, Limit = { Stk[A]() };
                                            local Limit = A + Inst[5] - 2;
                                            local Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            ::hgukWcuD::
                                        else
                                            local A = Inst[2];
                                            local Args = { };
                                            local Edx = 0;
                                            local Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                        end
                                    end
                                end
                            else
                                if Enum >= 36 then
                                    if Enum <= 37 then
                                        if Enum > 36 then
                                            Stk[Inst[2]] = Const[Inst[3]];
                                        else
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    else
                                        if Enum ~= 37 then
                                            if 38 ~= Enum then
                                                local Limit;
                                                local Edx;
                                                local Args;
                                                local B;
                                                local A;
                                                Stk[Inst[2]] = Env[Const[Inst[3]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = { };
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                do
                                                    return
                                                end;
                                                goto daHbUZZB;
                                            end;
                                            Stk[Inst[2]] = (Inst[3] ~= 0);
                                            ::daHbUZZB::
                                        else
                                            Stk[Inst[2]] = (Inst[3] ~= 0);
                                        end
                                    end
                                else
                                    if Enum <= 33 then
                                        local Results;
                                        local Limit;
                                        local Edx;
                                        local Args;
                                        local B;
                                        local A;
                                        Stk[Inst[2]] = Env[Const[Inst[3]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                        Limit = A + Inst[5] - 2;
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Stk[Idx] = Results[Edx];
                                        end;
                                        Top = Limit;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Stk[A](Unpack(Args, 1, Limit - A));
                                        Top = A;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        do
                                            return
                                        end;
                                    else
                                        if 31 < Enum then
                                            if Enum > 34 then
                                                Stk[Inst[2]] = Env[Const[Inst[3]]];
                                                goto nQkwjYvl;
                                            end;
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            ::nQkwjYvl::
                                        else
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                        end
                                    end
                                end
                            end
                        else
                            if Enum >= 47 then
                                if 49 >= Enum then
                                    if 47 < Enum then
                                        if 49 == Enum then
                                            Stk[Inst[2]] = Stk[Inst[3]] | Const[Inst[5]];
                                        else
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    else
                                        local Results;
                                        local Limit;
                                        local Edx;
                                        local Args;
                                        local B;
                                        local A;
                                        Stk[Inst[2]] = Env[Const[Inst[3]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                        Limit = A + Inst[5] - 2;
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Stk[Idx] = Results[Edx];
                                        end;
                                        Top = Limit;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Stk[A](Unpack(Args, 1, Limit - A));
                                        Top = A;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        do
                                            return
                                        end;
                                    end
                                else
                                    if Enum < 52 then
                                        if Enum == 51 then
                                            Stk[Inst[2]] = { };
                                        else
                                            local A = Inst[2];
                                            local Args = { };
                                            local Edx = 0;
                                            local Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                        end
                                    else
                                        if Enum == 52 then
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        else
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    end
                                end
                            else
                                if 43 <= Enum then
                                    if 45 > Enum then
                                        if Enum == 43 then
                                            local Results;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            do
                                                return
                                            end;
                                        else
                                            local B;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local A;
                                            Stk[Inst[2]][Const[Inst[3]]] = Stk[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                        end
                                    else
                                        if 44 ~= Enum then
                                            if 46 ~= Enum then
                                                local Results;
                                                local Limit;
                                                local Edx;
                                                local Args;
                                                local B;
                                                local A;
                                                Stk[Inst[2]] = Env[Const[Inst[3]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                                Limit = A + Inst[5] - 2;
                                                Edx = 0;
                                                for Idx = A, Limit do
                                                    Edx = Edx + 1;
                                                    Stk[Idx] = Results[Edx];
                                                end;
                                                Top = Limit;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                B = Stk[Inst[3]];
                                                Stk[A + 1] = B;
                                                Stk[A] = B[Const[Inst[5]]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                Stk[Inst[2]] = Const[Inst[3]];
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                A = Inst[2];
                                                Args = { };
                                                Edx = 0;
                                                Limit = A + Inst[3] - 1;
                                                for Idx = A + 1, Limit do
                                                    Edx = Edx + 1;
                                                    Args[Edx] = Stk[Idx];
                                                end;
                                                Stk[A](Unpack(Args, 1, Limit - A));
                                                Top = A;
                                                InstrPoint = InstrPoint + 1;
                                                Inst = Instr[InstrPoint];
                                                do
                                                    return
                                                end;
                                                goto UXpV_PzE;
                                            end
                                            local Results;
                                            local Results, Limit;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results, Limit = _R(Stk[A](Unpack(Args, 1, Limit - A)));
                                            Limit = Limit + A - 1;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = Top;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Results, Limit = { Stk[A]() };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = { };
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]][Const[Inst[3]]] = Const[Inst[5]];
                                            ::UXpV_PzE::
                                        else
                                            local Results;
                                            local Limit;
                                            local Edx;
                                            local Args;
                                            local B;
                                            local A;
                                            Stk[Inst[2]] = Env[Const[Inst[3]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            B = Stk[Inst[3]];
                                            Stk[A + 1] = B;
                                            Stk[A] = B[Const[Inst[5]]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            Stk[Inst[2]] = Const[Inst[3]];
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            A = Inst[2];
                                            Args = { };
                                            Edx = 0;
                                            Limit = A + Inst[3] - 1;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            Stk[A](Unpack(Args, 1, Limit - A));
                                            Top = A;
                                            InstrPoint = InstrPoint + 1;
                                            Inst = Instr[InstrPoint];
                                            do
                                                return
                                            end;
                                        end
                                    end
                                else
                                    if 41 > Enum then
                                        local Results;
                                        local Limit;
                                        local Edx;
                                        local Args;
                                        local B;
                                        local A;
                                        Stk[Inst[2]] = Env[Const[Inst[3]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                        Limit = A + Inst[5] - 2;
                                        Edx = 0;
                                        for Idx = A, Limit do
                                            Edx = Edx + 1;
                                            Stk[Idx] = Results[Edx];
                                        end;
                                        Top = Limit;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Stk[Inst[3]][Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        B = Stk[Inst[3]];
                                        Stk[A + 1] = B;
                                        Stk[A] = B[Const[Inst[5]]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        Stk[Inst[2]] = Const[Inst[3]];
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        A = Inst[2];
                                        Args = { };
                                        Edx = 0;
                                        Limit = A + Inst[3] - 1;
                                        for Idx = A + 1, Limit do
                                            Edx = Edx + 1;
                                            Args[Edx] = Stk[Idx];
                                        end;
                                        Stk[A](Unpack(Args, 1, Limit - A));
                                        Top = A;
                                        InstrPoint = InstrPoint + 1;
                                        Inst = Instr[InstrPoint];
                                        do
                                            return
                                        end;
                                    else
                                        if 38 <= Enum then
                                            if 42 ~= Enum then
                                                do
                                                    return
                                                end;
                                                goto FvnlwwCo;
                                            end
                                            local A = Inst[2];
                                            local Args = { };
                                            local Edx = 0;
                                            local Limit = Top;
                                            for Idx = A + 1, Limit do
                                                Edx = Edx + 1;
                                                Args[Edx] = Stk[Idx];
                                            end;
                                            local Results = { Stk[A](Unpack(Args, 1, Limit - A)) };
                                            local Limit = A + Inst[5] - 2;
                                            Edx = 0;
                                            for Idx = A, Limit do
                                                Edx = Edx + 1;
                                                Stk[Idx] = Results[Edx];
                                            end;
                                            Top = Limit;
                                            ::FvnlwwCo::
                                        else
                                            do
                                                return
                                            end;
                                        end
                                    end
                                end
                            end
                        end
                    end
                    InstrPoint = InstrPoint + 1;
                end;
            end;
            A, B = _R(PCall(Loop))
            if not A[1] then
                local line = Chunk[7][InstrPoint] or '?'
                error('EssaEF Error: ' .. line .. ', Check Your Source Code!:' .. A[2])
            else
                return Unpack(A, 2, B)
            end;
        end;
    end
    local essaprimewasdaddybuttooba = function()
        return _ENV
    end;
    return EssaSubway(EssaDeserlizer(), { }, essaprimewasdaddybuttooba())();
end)
local death
death = function()
    return death()
end
return fJVmEp(select, coroutine.wrap, string['byte'], string['char'], string['sub'], table['concat'], math['ldexp'], setmetatable, select, table.unpack, tonumber, string['reverse'], 'CJ`,]h|R`6%+2O7R8%lEjx|R$Ja*B[eR5z<,$kPHB2:+$YIZG)pbAkdH;Id*TvAY"1ozcj>M;IV*]OdRSz2cAkeS91}TbOASiG=,vnJHAJR*&6dR$/_aAklH[2TfCZBfowAb$iTH;I9@^jKU!/nxd9@GB23c%YbRVJ`,{h|RvM&+"OScxwuxbjJB81_Fr6bRVJnx2u|R"Lb*tNdRoz_,`t>is4A.>OdRRGWcAk@G91ORXOASUM=,$kLHB2CG_j5Xnz]d8w}MpOb*u6eR/LmcAk!S91lcPOAS=L=,vnHHAJDG_j$SzwtE,y>iVNp@PvAY"1Ybbj>M<1aD_j5XzwB.}v|R_N++fvdR*qecAkyS91=k+NASs)<,rzgM#8Z*B[9X"1ozbjtH91;:`ZXdzwtE3u|RK7a*XvbX"1j:6i@i74A.`ZdR;4WcAkNN81Di&NAS*w^a4iyo<13E_j7RRz"d6iuoxMUfPOAS>Lnxbv|R6La*tN6X"1d06i@i;4A.)YdRXUhzT71XH3A.^jdR$/ecAkkS<1&+%*bX"1t06iLBt4A.!OdRSzecAkGS;IXD_j$SywAb5u|RV6%+U8!Rpwne4iiM8I;+pN$R57WcAkRN=I?B~@Vc"IecAku081p@OOASgG=,:mHHAJh*^jgSywB.`t3XG3A.1NcR[+dE|t|RqL4+"OdRB2WcAkrH91RYLOAS!D=,$kqo"LIDqZtbxwtEeo|RB22+LPcRjw=,6iES<Ij*%[9Rpw=0bjZH91V<<Y(ZRzlc&!gM:7V*Ak}W574zJ5kMx23+hNdRAJ>0d9&GB28@^j7RVzozbj!G[25+8k9R4zlE2iiS<IvEr6(S4Ovx#3|R"OLK+NASWXnxYv(zyJV<8YgS?+nx@0&GAJvEqNfRozlE3iyo<1++^jgS47^y=t]MR2#+Ik9R2U_ajjso8I/Z&*7X)qG0:m)M67KK!ZDZqz.z2iAS<1A.Nl9Rqz<,8wiM67[FqZDZqz`0ljrHh2#+lN7R4GmE8uKu$Jlc9YeX@+nx=t:Mx2!+b77RX%lETmW:=1A.9*9R_/_awn|R;IS*B[#RQG{0rzVNK7KKra3dhwux2itH;I3+.kbR67<,#i)G813+1ZoahwAb9wsoj2A.V[7R!w<,48+GB2e*TvAY:490ll+M162+Aw9R.!<,llTd7IT*|jce)qW0lleMZO,+uC#RFP_a]0Ku91A.*[bR@Z{0AkNN@5+WuZycxzoz3i)G~O6=5ZZX47exllqM5OU*tNjS"1*E3iY:8I;:_Y%flwAb7i|Rl6S***fRq!<,bj.M$JT*WCGT"1+x3iY:GK`M+Z*TPG<a!i3X9Ic*hN7RB8<,/5.M81o@9*fRowmxbjKu[Mp@5Z$S1zwbbj@i>1.I%YdR%wCd$keM"7T*tNBYci<aAkXH81E?_YDZhwAbxz??gM;:8YhfRz10fjVd=Ik*5N8eQzsHgjhHP8::^jkS"12/2iiM91U*LP7R:w^a6igM8IRY9YlTQzQbbjbH;Ii*SCcR:4ex2ieM?82+uO=bgDJzvn|R7IS*$YgRnR<aJk|R74l/lNiYG)fx:meMq72+pN7R$w:d2iXd81T*$YeR6wydn#)M;42+LP7RnwozljxH;IeOTC!Y?Z{0J5)MK7TfPCcR+w^a@0$GAJ"kUvfR,OmE$iKu9IE?$YSchweEHk|R<1D?_Y(ZQz90bj?z=1h*"O|d?+=,9i|R`6++**#R0wIbAkr`91sHr6dR+/nx3i")<IeYr6*Tzt>0GyHN*6.+6O$R)fnxYv(zxJ!B%Y=b47>x^7eMFK*+"O7R#wp.cjF;=1g*LD!RxUnxbj~R#M`M%Y*Tqzgbkj>G;I)Sr6nTLlnx+ygMvM3+*Z7RQz^a$w&G9Ik*+ObR47;aljgM>P`M2Z(ZmR<a!i~ROPfOPCcRRzmx7iNH74A.8YhfRz)H2i*zAMV<m6fRjw6dbjyo<18=}@#R:4;a3i)GUN)+SOAS47<a3i!G<1b*U89R#cmEcv(zAMp@xZNbkzEHgjyo<1&Z~@#RA2ex#i@G<1g*y69R>/`,9w~RlN;:aaASoz9EljlH<I[(^jKUF)>xvnTd$JtEiNASd%mx`h|RgJ*+/[7RCJ_a$iES<I.(^jASpzW/fjZHA5#+>O%fhz2/bjPN<ITKUvRb/LBz8w%zRMB.8YbRpw(yljzH;Ib*WO8eQz1cUo+MG3o@CaeYF)>x|viMeP3+aO=bPG<a3i>Ga7R*xZKU_nBzvn<MK75+2O#RXGnx@ysorLoj%Y|d4zR.cjq0=I9=%*dR/LBzll&Mx2#+dl!RU2mEF3h5LOfOfaIa0z=0jj%d>1:+TvWcnR!0AkHNA5/+6]9R=t_ah9(zKOE?ea3dxzHGjjyo>1X<SC8ecixzbjoMx24+&OFTozlEjj9j>11c&*_c:42048"MpO/+ow#RYznx#8t``N)Pba|dozL:ijeM=Iuc~@?bhDm0d9DN6L/+aO!Rv!mEU7soOPORuZ$SuzVEkj>i=I9@pN$Rzt*0^7PN?8/+m]#R9%nxm9(z=Ilcfa$SWz(:kj4o;Il*Z[9R|7`,F3(z*NLK{ZZX3O[zQ0]M:L*+.k!RAo_a}7~R)N}TDa_W0zneijMu=1yO&*|dhDZzu6FNB2.+1NeY?+RzKmBN~O%+/[7R2z^ac7VdFNLKLaZXpzY;ijYY=I2Sr6IaLlm0Ak{MUN.+PP!RG5mE#14)`N3+KaeYzz]dkj~X>1kYr6?bG)l0Xv"M?M)+Z[!R&w_a61JBbOm/~ZeYjzadjj<S>14@SCBe:4u0^7LNP8.+f79R"7_a6iVd$J2ZXa]crzIbjjqS=IRY~@raztN0|vHN!P++4k#RuUmEw63XxMV<Oa*TqzEHjj~R=IaK~@Vc#/W0C!FNP8)+LD#RGdmEp4&GrOIDPCcR}c`,g2"!1NE?OCmTA2F0hx{M#M,+:+9RQrmE>5KuENIDLaFTsz2xgjQ{=14Z~@iY#/%za2"MOP)+>O!RArnx913XQMiV>Zoaoz#GijU0<IaRqN?bA2O0/5)Ma7++|v!R]Z`,#3gMAM)PHaDZYz=0bj6S>1Qbr6ad@+nxJ5HN*6,+Vl#Ra2nx06"!6OE?_YeYRzR.cjq@<I_PTCmZiwN0a2]MfM*+Fl!R)f`,t4JBUNp@`Z]cvzW/hjVp=1{WUvHZRz@za2BNrI*+^j!R4zmxq4sowMwLDa3dszR.cj{:=1?WTCRbX%ex#i%j=1$STCmTiwux/5.MfM(+X7!RRr_anx&GFN5g"ZKUsz+xhjU{<IfO%YNb@+Jz[h{Mf8&+<w!RWa_a!1&G[MwL"ZScrzSdhjT*=1FN~@*ZQG~zbj@MvM)+KO!R/qnxsz&GlN;:_Y7RozR.cjr`<Ir@pN$RnRO0UoDNQ5++9N#Rzw_aN5(z=IE?Ga$SWzYbjj4o<1)+pNEZ@+nx11}M*6#+HD!RXXmE|03X*NwL:Z!Yqz(yijj#=1~T~@tb"I5z$k}MwJ*+m]9RvfnxevgMUNoj]Z%fpz+xijS6=1TK}jRbG)YzKm:M!P3+F[9RnR`,2i+GkN(+`Z!R#!lEg2KuFNRY2ZeYszAzhj")<I7S&*$YnReEmxsoEN6=[ZgSpzIbijf5=1ySTC.Z@+%z48>MK7$+]O!R!imE&wt`@MzS&ZtbrzCdhjP*<IbHqNDY:4.zXv>MfM)+%N!Rd%mx51soAMp@=Z_Whz=Eij{u<1PUr6xbo![zu6}M!P3+H,!Rao`,G3Vd$J,W{Ztbtzfebj4o;I9EqNmZzt5zyu=?VN)P_jlZWU5z=t<M@J&+iC!RHX_aA3gM#ME?/ZKUqzY;gjH;<IdK&*oaRzZzAk]Mw5(+K]9RuUnx_0KuwM%I6Z~Xmz10hj4o;IwOr6DZRzxz2i2)FN`M]Z8eUzYbcjjj<1=:|j:aRzRz=t>M_N%+]+9R?cmEnx(zENtE2Z_Wlz{xgj{i=1fO~@CYRzQz[h.M?8&+{O!RAPnx7i|d=1rHTC.ZciJzQ0+MK7&+V[7RQa`,$w&GQME?xZFTkzIbgjVd<IENr6_Wo!BzT7)MfM(+ow9R_Z`,Cw(zAMm/%Z~Xjz;ahj"u<IS?$Y.azt$z2i_M#8(+ma7R]fmE"0VdWN;:_Yceqz^:hjqM;I9=$YmZci_y#3&MvM&+Mk9RYXnxevgM$Mp@9ZhfRz=EhjHHgJ4+eC!RGX_a+yKu$JID9YIZ@+nx[h<M"7%+W]9RDJ_aOyt`wMzS6Zoamzp.cjRp<IcKr6FZ#/<yyu:MG3%+R[9RN,_,Gy??xJ6=<YlTVzYbcj`d;I_ITCfR}L`,kjt`91vHTC&Y`nRz11.Mx2&+^79R8R_amx~RQMID2ZKUlz>xgj_i=1:+Tv*ZiwQzn#+Mv8$+"Ocekz]dgj`d=1FG~@hYLlJz@0+M@5$+j79R;O`,kj~RgMp@xZlTkzQbgjXd=1V*m69RWMmEGw~RfM:duZXdjzMHgjWY=1EGqN$RA2Rz+y)MfM$+V[7R"L_aAw(z=IE?tZeYXz=0bj@u=1!LUvnZLlhz/5<MJO&+ma7RhX_a;m4)$ME?_Y*TSzx.gjES<I8ETCIZFX_yyu&M;I3+6]9R6U_aNy>i7I,Wn6lThDnxa2:MqL3+{O8emzVcGy:Mf8%+6O7RrU_alj(zwMV<8YhfRzj:fjJp<I4E&*AStf=,}vgM8IcD&*AS:4<a;m(z;LLKqZoa47^yn#TdQJojmZ.a?+nxu6&Mx2U<_@bR57>x&!!MeP3+!+7R!7^alxgMiJfO[YXdSzHerzoM%24+J[7R#R_aEwgMBM,WuZ!Y(q=,2i>G;I9=$YBY57<ajx>i9Ii*_w9R2wdcgjjHK7$I_jbR!cfx6ibH;I9=$YbXzt<a#i+Gg5"a9YdRA2Iz"2+M%2l/xZSc9ceE9i~RPM3+m6bR57fx3ivH74sE!*dRxw^alj&G[J`MuZ~XPG=,9i.G"7NR9YeYmR<a#iHH/O$+5NycmR=,8iVd$JtEmZ(ZjzwbAk|R!1g*eO.aQz"dhx%z7I;:_YoaWz90bjPH%2HDQvdR4zlEzuso=Ioj%Y$SizR.cjJN<IF?pN$R#/_ybj)Mf8#+ma7R,LmEhv(z<LUfqZ3dizA;fj4o;IM.q6lT`n?xllqM%2#+Ik9R7wR.cjgS=17=pN6XG)>xKm&M;I3+ma7R3w=0bjbp;Ia*2]7RT2_,7iES<Ia*ma7R"I`,!iyo<1++%*fR=4^a)k&G=IwLn6lTX%)yT7$MwJ#+:O7R7w_,3i&G9IOR9YjZQzwbbj<M<ITD%YbRztexn#Iu8Im/8Y%fF)>xhxiMeP3+V[7R2zmxlj>i6LE?_YFTWzmxfj4o;IB.q6lT#/)yC!!MuP3+V[7R~1lE<mW:%JtEn6lTci)y#3!Mg5D?_YjZQzp.cjXH=1c*SCmTQG)yhx!M;42+V[7R$w^a;m&GrLE?_Y=bQzR.cj)G=17=TvlTG)>xbj!M*62+V[7RY,^aeogM7IE?_Y%f47>xT7uM[25+PP$SWzSddji0;Ia*SCmT:4exvnqMF66+9N7Rd%mxYo>iGK%I%Y*TWz{xbjyo<1w@SCmTQGnxllqM<16+1N8RtzlE<mso<IE?_Y{QYzwzbj4o<1U?}@/T#/fxvnqM672+J[7Rm)lE<m>i9I;:_YIaXz,GdjkM;I9=pN7RG)>x+ysMrI3+V[7RN)lE0n(zAJE?_Y_WSzR.cjWu;I9=q6AS57>x[hsMAJ6+Mk7Rd%mxGkKu$Joj`Y(ZSzp.cjVp<1K.q6lTA2?xvnqM/O3+J[7Rx%^akjKu$J,W%Y*TWzD:cj"M;I9=TvnTWU?xyuqMG35+%[7Ra%^a>mKu$J2Z%YhfRzR.cjAS<17=pN$RtffxM');
