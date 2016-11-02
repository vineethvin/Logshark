﻿using System.Collections.Generic;
using LogParsers.Helpers;

namespace LogParsers
{
    /// <summary>
    /// Parses VizqlServer C++ logs to JSON.
    /// </summary>
    public sealed class VizqlServerCppParser : AbstractJsonParser, IParser
    {
        private static readonly string collectionName = ParserConstants.VizqlServerCppCollectionName;
        private static readonly IList<string> indexNames = new List<string> { "k", "file", "pid", "req", "sess", "sev", "worker" };
        private static readonly CollectionSchema collectionSchema = ParserUtil.CreateCollectionSchema(collectionName, indexNames);

        public override CollectionSchema CollectionSchema
        {
            get 
            {
                return collectionSchema;
            }
        }

        public VizqlServerCppParser() { }
        public VizqlServerCppParser(LogFileContext fileContext) : base(fileContext) { }
    }
}
