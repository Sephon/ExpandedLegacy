using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExpandedLegacy.Classes
{
    class Checkpoints
    {
        private List<Checkpoint> _checkpoints = new List<Checkpoint>();

        public void AddCheckpoint(Vector2 point)
        {
            _checkpoints.Add(new Checkpoint(point));
        }

        public Checkpoint GetNextCheckpoint(WorldItem item)
        {            
            if (_checkpoints.Count == 0)
                return null;
            
            var retrievedCP = _checkpoints[0];
            if (retrievedCP.IsInVicinity(item))
            {
                RemoveCheckpoint(retrievedCP);
                GetNextCheckpoint(item);
            }
            else
            {
                return retrievedCP;
            }

            return null;
        }

        public void RemoveCheckpoint(Checkpoint cp)
        {
            _checkpoints.Remove(cp);
        }
    }

    class Checkpoint
    {
        public Vector2 Position;
        private const int CHECKPOINT_SPLASH_AREA = 10;

        public Checkpoint(Vector2 point)
        {
            Position = point;
        }

        public bool IsInVicinity(WorldItem item)
        {
            if(item.GetRectangle().Intersects(GetRectangle()))
                return true;
            else
                return false;
        }

        private Rectangle GetRectangle()
        {
            return new Rectangle((int) Position.X - (CHECKPOINT_SPLASH_AREA / 2), (int) Position.Y - (CHECKPOINT_SPLASH_AREA  /2), CHECKPOINT_SPLASH_AREA, CHECKPOINT_SPLASH_AREA);
        }
    }
}
