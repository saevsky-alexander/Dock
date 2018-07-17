﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System.Runtime.Serialization;
using ReactiveUI;

namespace Dock.Model.Controls
{
    /// <summary>
    /// Document dock.
    /// </summary>
    public class DocumentDock : DockBase, IDocumentDock
    {
        private double _proportion;

        /// <inheritdoc/>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public double Proportion
        {
            get => _proportion;
            set => this.RaiseAndSetIfChanged(ref _proportion, value);
        }
    }
}
