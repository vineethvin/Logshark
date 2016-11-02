﻿using System.Collections.Generic;
using LogParsers.Helpers;

namespace LogParsers
{
    /// <summary>
    /// Parses VizPortal C++ logs to JSON.
    /// </summary>
    public sealed class VizportalCppParser : AbstractJsonParser, IParser
    {
        private static readonly string collectionName = ParserConstants.VizportalCppCollectionName;
        private static readonly IList<string> indexNames = new List<string> { "k", "file", "pid", "req", "sess", "sev", "worker" };
        private static readonly CollectionSchema collectionSchema = ParserUtil.CreateCollectionSchema(collectionName, indexNames);

        public override CollectionSchema CollectionSchema
        {
            get
            {
                return collectionSchema;
            }
        }

        public VizportalCppParser() { }
        public VizportalCppParser(LogFileContext fileContext) : base(fileContext) { }
    }
}
