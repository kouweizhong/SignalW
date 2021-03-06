﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Spreads.SignalW.Client;

namespace Spreads.SignalW.Connections {

    public class ConnectionMetadata {
        private ConcurrentDictionary<object, object> _metadata = new ConcurrentDictionary<object, object>();

        public Format Format { get; set; } = Format.Text;

        public object this[object key]
        {
            get
            {
                object value;
                _metadata.TryGetValue(key, out value);
                return value;
            }
            set
            {
                _metadata[key] = value;
            }
        }

        public T GetOrAdd<T>(object key, Func<object, T> factory) {
            return (T)_metadata.GetOrAdd(key, k => factory(k));
        }

        public T Get<T>(object key) {
            return (T)this[key];
        }
    }
}
