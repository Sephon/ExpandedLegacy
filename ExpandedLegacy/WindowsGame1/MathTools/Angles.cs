using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExpandedLegacy.MathTools
{
    class Angles
    {
        public enum Angle
        {
            South,
            SouthWest,
            West,
            NorthWest,
            North,
            NorthEast,
            East,
            SouthEast
        }

        public static double GetAngle(Vector2 object1Position, Vector2 object2Position) 
        {
            double theta = 180.0 / Math.PI * Math.Atan2(object1Position.X - object2Position.X, object2Position.Y - object1Position.Y);

            return theta;
        }

        public static Angle GetAngleDescription(double angle)
        {
            angle = 180 + angle;
            if (angle >=  0 && angle <= 22.5)
                return Angle.North;
            if (angle >= 22.5 && angle <= 67.5)
                return Angle.NorthEast;
            if (angle >= 67.5 && angle <= 112.5)
                return Angle.East;
            if (angle >= 112.5 && angle <= 157.5)
                return Angle.SouthEast;
            if (angle >= 157.5 && angle <= 202.5)
                return Angle.South;
            if (angle >= 202.5 && angle <= 247.5)
                return Angle.SouthWest;
            if (angle >= 247.5 && angle <= 292.5)
                return Angle.West;
            if (angle >= 292.5 && angle <= 337.5)
                return Angle.NorthWest;
            else
                return Angle.North;
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
