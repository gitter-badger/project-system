﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.LanguageServices.ProjectSystem;

namespace Microsoft.VisualStudio.ProjectSystem.LanguageServices
{
    /// <summary>
    ///     Applies <see cref="IProjectVersionedValue{T}"/> values to a <see cref="IWorkspaceProjectContext"/>.
    /// </summary>
    internal interface IApplyChangesToWorkspaceContext
    {
        /// <summary>
        ///     Returns an enumerable of evaluation rules that should passed to
        ///     <see cref="ApplyEvaluation(IProjectVersionedValue{IProjectSubscriptionUpdate}, bool, CancellationToken)"/>.
        /// </summary>
        IEnumerable<string> GetEvaluationRules();

        /// <summary>
        ///     Returns an enumerable of design-time rules that should passed to
        ///     <see cref="ApplyDesignTime(IProjectVersionedValue{IProjectSubscriptionUpdate}, bool)"/>.
        /// </summary>
        IEnumerable<string> GetDesignTimeRules();

        /// <summary>
        ///     Initializes the service with the specified <see cref="IWorkspaceProjectContext"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="context"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     <see cref="Initialize(IWorkspaceProjectContext)"/> has already been called.
        /// </exception>
        void Initialize(IWorkspaceProjectContext context);

        /// <summary>
        ///     Applys evaluation changes to the underlying <see cref="IWorkspaceProjectContext"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="update"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     <see cref="Initialize(IWorkspaceProjectContext)"/> has not been called.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="IApplyChangesToWorkspaceContext"/> has been disposed of.
        /// </exception>
        /// <remarks>
        ///     Note: Cancelling the <paramref name="cancellationToken"/> may result in the underlying
        ///     <see cref="IWorkspaceProjectContext"/> to be left in an inconsistent state with respect
        ///     to the project snapshot state. The cancellation token should only be cancelled with the
        ///     intention that the <see cref="IWorkspaceProjectContext"/> will be immediately disposed.
        /// </remarks>
        void ApplyEvaluation(IProjectVersionedValue<IProjectSubscriptionUpdate> update, bool isActiveContext, CancellationToken cancellationToken);

        /// <summary>
        ///     Applys evaluation changes to the underlying <see cref="IWorkspaceProjectContext"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="update"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     <see cref="Initialize(IWorkspaceProjectContext)"/> has not been called.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The <see cref="IApplyChangesToWorkspaceContext"/> has been disposed of.
        /// </exception>
        /// <remarks>
        ///     Note: Cancelling the <paramref name="cancellationToken"/> may result in the underlying
        ///     <see cref="IWorkspaceProjectContext"/> to be left in an inconsistent state with respect
        ///     to the project snapshot state. The cancellation token should only be cancelled with the
        ///     intention that the <see cref="IWorkspaceProjectContext"/> will be immediately disposed.
        /// </remarks>
        void ApplyDesignTime(IProjectVersionedValue<IProjectSubscriptionUpdate> update, bool isActiveContext, CancellationToken cancellationToken);
    }
}
