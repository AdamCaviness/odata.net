//---------------------------------------------------------------------
// <copyright file="ODataParameterWriter.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.OData.Core
{
    #region Namespaces
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
#if ODATALIB_ASYNC
    using System.Threading.Tasks;
#endif
    using Microsoft.OData.Edm;
    using Microsoft.OData.Core.Json;
    #endregion Namespaces

    /// <summary>Base class for OData collection writers.</summary>
    public abstract class ODataParameterWriter
    {
        /// <summary>Start writing a parameter payload.</summary>
        public abstract void WriteStart();

#if ODATALIB_ASYNC
        /// <summary>Asynchronously start writing a parameter payload.</summary>
        /// <returns>A task instance that represents the asynchronous write operation.</returns>
        public abstract Task WriteStartAsync();
#endif

        /// <summary>Start writing a value parameter.</summary>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <param name="parameterValue">The value of the parameter to write (null/ODataComplexValue/ODataEnumValue/primitiveClrValue).</param>
        public abstract void WriteValue(string parameterName, object parameterValue);

#if ODATALIB_ASYNC
        /// <summary>Asynchronously start writing a value parameter.</summary>
        /// <returns>A task instance that represents the asynchronous write operation.</returns>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <param name="parameterValue">The value of the parameter to write.</param>
        public abstract Task WriteValueAsync(string parameterName, object parameterValue);
#endif

        /// <summary>Creates an <see cref="T:Microsoft.OData.Core.ODataCollectionWriter" /> to write the value of a collection parameter.</summary>
        /// <returns>The newly created <see cref="T:Microsoft.OData.Core.ODataCollectionWriter" />.</returns>
        /// <param name="parameterName">The name of the collection parameter to write.</param>
        public abstract ODataCollectionWriter CreateCollectionWriter(string parameterName);

#if ODATALIB_ASYNC
        /// <summary>Asynchronously creates an <see cref="T:Microsoft.OData.Core.ODataCollectionWriter" /> to write the value of a collection parameter.</summary>
        /// <returns>The asynchronously created <see cref="T:Microsoft.OData.Core.ODataCollectionWriter" />.</returns>
        /// <param name="parameterName">The name of the collection parameter to write.</param>
        public abstract Task<ODataCollectionWriter> CreateCollectionWriterAsync(string parameterName);
#endif

        /// <summary> Creates an <see cref="T:Microsoft.OData.Core.ODataWriter" /> to write an entry. </summary>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <returns>The created writer.</returns>
        public abstract ODataWriter CreateEntryWriter(string parameterName);

#if ODATALIB_ASYNC
        /// <summary>Asynchronously creates an <see cref="T:Microsoft.OData.Core.ODataWriter" /> to  write an entry.</summary>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <returns>The asynchronously created <see cref="T:Microsoft.OData.Core.ODataWriter" />.</returns>
        public abstract Task<ODataWriter> CreateEntryWriterAsync(string parameterName);
#endif

        /// <summary> Creates an <see cref="T:Microsoft.OData.Core.ODataWriter" /> to write a feed. </summary>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <returns>The created writer.</returns>
        public abstract ODataWriter CreateFeedWriter(string parameterName);

#if ODATALIB_ASYNC
        /// <summary>Asynchronously creates an <see cref="T:Microsoft.OData.Core.ODataWriter" /> to  write a feed.</summary>
        /// <param name="parameterName">The name of the parameter to write.</param>
        /// <returns>The asynchronously created <see cref="T:Microsoft.OData.Core.ODataWriter" />.</returns>
        public abstract Task<ODataWriter> CreateFeedWriterAsync(string parameterName);
#endif

        /// <summary>Finish writing a parameter payload.</summary>
        public abstract void WriteEnd();

#if ODATALIB_ASYNC
        /// <summary>Asynchronously finish writing a parameter payload.</summary>
        /// <returns>A task instance that represents the asynchronous write operation.</returns>
        public abstract Task WriteEndAsync();
#endif

        /// <summary>Flushes the write buffer to the underlying stream.</summary>
        public abstract void Flush();

#if ODATALIB_ASYNC
        /// <summary>Asynchronously flushes the write buffer to the underlying stream.</summary>
        /// <returns>A task instance that represents the asynchronous operation.</returns>
        public abstract Task FlushAsync();
#endif
    }
}
