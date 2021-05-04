#if SERVER
using System;
using System.Diagnostics;
namespace UnityEngine
{
    public class Time
    {
        static Time()
        {
            startupTicks = ticks;
        }

        private static long _frameCount = 0;

        /// <summary>
        /// The total number of frames that have passed (Read Only).
        /// </summary>
        public static long frameCount { get { return _frameCount; } }

        static long startupTicks = 0;

        static long freq = 0;

        /// <summary>
        /// Tick count
        /// </summary>
        static public long ticks
        {
            get
            {
                
                if (Stopwatch.Frequency>0)
                {
                    freq = Stopwatch.Frequency;
                }
                else
                {
                    freq = -1;
                    return Environment.TickCount * 10000;
                }
                
                long c = Stopwatch.GetTimestamp();
                return (long)(((double)c) * 1000 * 10000 / ((double)freq));
            }
        }

        private static long lastTick = 0;
        private static float _deltaTime = 0;

        /// <summary>
        /// The time in seconds it took to complete the last frame (Read Only).
        /// </summary>
        public static float deltaTime
        {
            get
            {
                return _deltaTime;
            }
        }

        private static float _fixedDeltaTime = 0.02f;

        public static float fixedDeltaTime 
        { 
            get
            {
                return _fixedDeltaTime;
            }
        }


        private static float _time = 0;
        /// <summary>
        ///  The time at the beginning of this frame (Read Only). This is the time in seconds
        ///  since the start of the game.
        /// </summary> 
        public static float time
        {
            get
            {
                return _time;
            }
        }


        /// <summary>
        /// The real time in seconds since the started (Read Only).
        /// </summary>
        public static float realtimeSinceStartup
        {
            get
            {
                long _ticks = ticks;
                return (_ticks - startupTicks) / 10000000f;
            }
        }

        public static void Tick()
        {
            long _ticks = ticks;


            _frameCount++;
            if (_frameCount == long.MaxValue)
                _frameCount = 0;

            if (lastTick == 0) lastTick = _ticks;
            _deltaTime = (_ticks - lastTick) / 10000000f;
            _time = (_ticks - startupTicks) / 10000000f;
            lastTick = _ticks;
        }

    }
}
#endif