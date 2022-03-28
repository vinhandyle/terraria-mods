using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod
{
    public delegate void ExtraAction();

    public static class Helper
    {
        #region Spawn helpers
        public static void MoveTowards(this NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var Move = playerTarget - npc.Center;
            float Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            Move = (npc.velocity * turnResistance + Move) / (turnResistance + 1f);
            Length = Move.Length();
            if (Length > speed)
            {
                Move *= speed / Length;
            }
            npc.velocity = Move;
        }

        public static Vector2 RandomPointInArea(Vector2 A, Vector2 B)
        {
            return new Vector2(Main.rand.Next((int)A.X, (int)B.X) + 1, Main.rand.Next((int)A.Y, (int)B.Y) + 1);
        }

        public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float Speed)
        {
            Vector2 Move = (B - A);
            return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
        }
    }
    #endregion
}