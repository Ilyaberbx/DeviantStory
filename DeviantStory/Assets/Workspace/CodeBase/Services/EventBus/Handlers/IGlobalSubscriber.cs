﻿namespace Workspace.CodeBase.Services.EventBus.Handlers
{
    public interface IGlobalSubscriber
    {
        public int Priority { get; }
    }
}