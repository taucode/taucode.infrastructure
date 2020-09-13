﻿using System;

namespace TauCode.Infrastructure.Time
{
    public class ShiftedTimeProvider : ITimeProvider
    {
        public ShiftedTimeProvider(TimeSpan shift)
        {
            this.Shift = shift;
        }

        public TimeSpan Shift { get; }

        public DateTimeOffset GetCurrent() => DateTimeOffset.UtcNow + this.Shift;

        public static ShiftedTimeProvider CreateTimeMachine(DateTimeOffset fakeNow) =>
            new ShiftedTimeProvider(fakeNow - DateTimeOffset.UtcNow);
    }
}
