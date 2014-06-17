using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExpandedLegacy.MathTools
{
    class Angles
    {
        public static double GetAngle(Vector2 object1Position, Vector2 object2Position) 
        {
            double theta = 180.0 / Math.PI * Math.Atan2(object1Position.X - object2Position.X, object2Position.Y - object1Position.Y);

            return theta;
        }

        public static double AngleBetweenVectors(Vector2 obj1, Vector2 obj2)
        {
            obj1.Normalize();
            obj2.Normalize();

            // Returns the angle in radians
            return ((2 * Math.PI) - Math.Acos(Vector2.Dot(obj1, obj2)));
        }

    }
}
