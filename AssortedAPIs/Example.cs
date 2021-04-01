//using System;
//using System.Reflection;

//using MonoMod.Cil;

//using Rein.ILHookHelperAPI;

//static class Example
//{
//static void MyILHook(ILContext il) => new ILCursor(il)
//    .Goto(MoveType.After, x => x.MatchLdfld<Cheese>(nameof(Cheese.goodLevel)))
//    .OP_Dup()
//    .AddLocal<int>(out var index)
//    .OP_StLocal(index)
//    .Goto(MoveType.After, x => x.MatchLdfld<NotCheese>(nameof(NotCheese.badLevel)))
//    .OP_Pop()
//    .OP_LdLocal(index);
//}

//public class Cheese
//{
//    public int goodLevel;
//}
//public class NotCheese
//{
//    public int badLevel;
//}