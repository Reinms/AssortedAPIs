//namespace Rein.ILHookHelperAPI
//{
//    using System;
//    using System.Runtime.CompilerServices;
//    using System.Runtime.InteropServices;

//    using Mono.Cecil.Cil;

//    using MonoMod.Cil;

//    using MatchExpr = System.Func<Mono.Cecil.Cil.Instruction, System.Boolean>;

//    public static class Match
//    {
//        private static void asd()
//        {
//            Instruction instr = null;

//            instr.Match
//        }

//        public static MatchExpr Add() => x => x.MatchAdd();
//        public static MatchExpr Add_Ovf() => x => x.MatchAddOvf();
//        public static MatchExpr Add_Ovf_Un() => x => x.MatchAdd_OvfUn();
//        public static MatchExpr And() => x => x.MatchAnd();
//        public static MatchExpr Arglist() => x => x.MatchArglist();
//        public static MatchExpr Beq(ILLabel label) => x => x.MatchBeq(label);
//        public static unsafe MatchExpr Beq(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBeq(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Bge(ILLabel label) => x => x.MatchBge(label);
//        public static unsafe MatchExpr Bge(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBge(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Bge_Un(ILLabel label) => x => x.MatchBgeUn(label);
//        public static unsafe MatchExpr Bge_Un(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBgeUn(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Bgt(ILLabel label) => x => x.MatchBgt(label);
//        public static unsafe MatchExpr Bgt(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBgt(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Bgt_Un(ILLabel label) => x => x.MatchBgtUn(label);
//        public static unsafe MatchExpr Bgt_Un(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBgtUn(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Ble(ILLabel label) => x => x.MatchBle(label);
//        public static unsafe MatchExpr Ble(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBle(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Ble_Un(ILLabel label) => x => x.MatchBleUn(label);
//        public static unsafe MatchExpr Ble_Un(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBleUn(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Blt(ILLabel label) => x => x.MatchBlt(label);
//        public static unsafe MatchExpr Blt(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBlt(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Blt_Un(ILLabel label) => x => x.MatchBltUn(label);
//        public static unsafe MatchExpr Blt_Un(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBltUn(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//        public static MatchExpr Bne_Un(ILLabel label) => x => x.MatchBneUn(label);
//        public static unsafe MatchExpr Bne_Un(out ILLabel label)
//        {
//            label = null!;
//            ref var lab = ref label;
//            var ptr = Unsafe.AsPointer(ref lab);
//            return x =>
//            {
//                var res = x.MatchBneUn(out var lab);
//                if(res)
//                {
//                    ref ILLabel labRef = ref Unsafe.AsRef<ILLabel>(ptr);
//                    labRef = lab;
//                    return true;
//                }
//                return false;
//            };
//        }
//    }
//}
