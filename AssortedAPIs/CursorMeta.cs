namespace Rein.ILHookHelperAPI
{
    using System;

    using Mono.Cecil.Cil;

    using MonoMod.Cil;

    using MatchExpr = System.Func<Mono.Cecil.Cil.Instruction, System.Boolean>;

    public enum Direction
    {
        Next, Prev
    }


    public delegate void CursorExpr(ILCursor? cursor);

    public static partial class CursorExtensions
    {
        public static ILCursor? Goto(this ILCursor? cursor, ILLabel label) => cursor.Goto(MoveType.AfterLabel, label);
        public static ILCursor? Goto(this ILCursor? cursor, MoveType moveType, ILLabel label)
        {
            cursor?.GotoLabel(label, moveType);
            return cursor;
        }
        public static ILCursor? Goto(this ILCursor? cursor, params MatchExpr[] conditions) => cursor.Goto(Direction.Next, MoveType.AfterLabel, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, Direction direction, params MatchExpr[] conditions) => cursor.Goto(direction, MoveType.AfterLabel, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, MoveType moveType, params MatchExpr[] conditions) => cursor.Goto(Direction.Next, moveType, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, Action onFail, params MatchExpr[] conditions) => cursor.Goto(onFail, Direction.Next, MoveType.AfterLabel, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, Action onFail, Direction direction, params MatchExpr[] conditions) => cursor.Goto(onFail, direction, MoveType.AfterLabel, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, Action onFail, MoveType moveType, params MatchExpr[] conditions) => cursor.Goto(onFail, Direction.Next, MoveType.AfterLabel, conditions);
        public static ILCursor? Goto(this ILCursor? cursor, Action onFail, Direction direction, MoveType moveType, params MatchExpr[] conditions)
        {
            if(cursor is not ILCursor cur) return null;
            if(cursor.Goto(direction, moveType, conditions) is not ILCursor res)
            {
                res = null;
                onFail();
            }
            return res;
        }
        public static ILCursor? Goto(this ILCursor? cursor, Direction direction, MoveType moveType, params MatchExpr[] conditions) => direction switch
        {
            Direction.Next => cursor?.TryGotoNext(moveType, conditions) ?? false ? cursor : null,
            Direction.Prev => cursor?.TryGotoPrev(moveType, conditions) ?? false ? cursor : null,
            _ => null
        };

        //TODO: Support find

        public static ILCursor? Offset(this ILCursor? cursor, Int32 offset)
        {
            if(cursor is not null) cursor.Index += offset;
            return cursor;
        }

        public static ILCursor? DefLabel(this ILCursor? cursor, out ILLabel? label)
        {
            label = cursor?.DefineLabel();
            return cursor;
        }

        public static ILCursor? Label(this ILCursor? cursor, out ILLabel? label)
        {
            label = cursor?.MarkLabel();
            return cursor;
        }

        public static ILCursor? Label(this ILCursor? cursor, ILLabel? label)
        {
            if(label is not null)
            {
                cursor?.MarkLabel(label);
            }
            return cursor;
        }

        public static ILCursor? Log(this ILCursor? cursor, Action<String> logger)
        {
            if(cursor is not null)
            {
                logger(cursor.ToString());
            }
            return cursor;
        }
        public static ILCursor? LogContext(this ILCursor? cursor, Action<String> logger)
        {
            if(cursor is not null)
            {
                logger(cursor.Context?.ToString() ?? "ILContext was null");
            }
            return cursor;
        }

        public static ILCursor? Position(this ILCursor? cursor, out Int32? position)
        {
            position = cursor?.Index;
            return cursor;
        }
        public static ILCursor? Position(this ILCursor? cursor, Int32? position)
        {
            if(position is Int32 pos && cursor is not null)
            {
                cursor.Index = pos;
            }
            return cursor;
        }

        public static ILCursor? AddLocal<T>(this ILCursor? cursor, out Int32 index)
        {
            index = cursor.Context.Body.Variables.Count;
            cursor.Context.Body.Variables.Add(new VariableDefinition(cursor.Context.Import(typeof(T))));
            return cursor;
        }

        public static ILCursor? AddRef<T>(this ILCursor? cursor, T value, out Int32 id)
        {
            id = cursor.AddReference<T>(value);
            return cursor;
        }
        public static ILCursor? GetRef<T>(this ILCursor? cursor, Int32 id)
        {
            cursor.EmitGetReference<T>(id);
            return cursor;
        }
        public static ILCursor? EmitRef<T>(this ILCursor? cursor, T value, out Int32 id)
        {
            id = cursor.EmitReference<T>(value);
            return cursor;
        }

        public static ILCursor? Delete(this ILCursor? cursor) => cursor?.Remove();

    }
}
