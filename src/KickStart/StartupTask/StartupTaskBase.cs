﻿using System;
using System.Collections.Generic;

namespace KickStart.StartupTask
{
    /// <summary>
    /// Base class for start tasks
    /// </summary>
    public abstract class StartupTaskBase : IStartupTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartupTaskBase"/> class.
        /// </summary>
        protected StartupTaskBase()
        {
            Priority = int.MaxValue;
        }

        /// <summary>
        /// Gets the priority of this task. Lower numbers run first.
        /// </summary>
        /// <value>
        /// The priority of this task.
        /// </value>
        public int Priority { get; set; }

        /// <summary>
        /// Runs the startup task with the specified context <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The data dictionary shared with all starter modules.</param>
        public abstract void Run(IDictionary<string, object> data);
    }
}