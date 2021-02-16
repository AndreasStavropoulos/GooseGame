﻿using System.Windows.Media;

namespace TheGooseGame.Square
{
    public class Bridge : NormalSquare
    {
        public override void Action(IPlayer player)
        {
            player.MovePlayerToPosition(player, 12);
        }

        public Bridge(int id) : base(id)
        {
            BackColor = Colors.Green;
        }
    }
}