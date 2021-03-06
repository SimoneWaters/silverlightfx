﻿// SetVisibility.cs
// Copyright (c) Nikhil Kothari, 2008. All Rights Reserved.
// http://www.nikhilk.net
//
// Silverlight.FX is an application framework for building RIAs with Silverlight.
// This project is licensed under the BSD license. See the accompanying License.txt
// file for more information.
// For updated project information please visit http://projects.nikhilk.net/SilverlightFX.
//

using System;
using System.Windows;
using System.Windows.Interactivity;

namespace SilverlightFX.UserInterface.Actions {

    /// <summary>
    /// An action that sets the visibility of a particular element.
    /// </summary>
    public sealed class SetVisibility : TriggerAction<FrameworkElement> {

        /// <summary>
        /// Represents the TargetName property.
        /// </summary>
        public static readonly DependencyProperty TargetNameProperty =
            DependencyProperty.Register("TargetName", typeof(string), typeof(SetVisibility), null);

        /// <summary>
        /// Gets or sets the target element whose visibility should be set.
        /// </summary>
        public string TargetName {
            get {
                return (string)GetValue(TargetNameProperty);
            }
            set {
                SetValue(TargetNameProperty, value);
            }
        }

        private FrameworkElement GetTarget() {
            string targetName = TargetName;
            if (String.IsNullOrEmpty(targetName)) {
                return AssociatedObject;
            }
            else {
                return AssociatedObject.FindNameRecursive(targetName) as FrameworkElement;
            }
        }

        /// <internalonly />
        protected override void InvokeAction(EventArgs e) {
            FrameworkElement target = GetTarget();
            if (target == null) {
                throw new InvalidOperationException("The target of the GoToState action was not found or was not a Control.");
            }

            target.Visibility = Visibility;
        }
    }
}
