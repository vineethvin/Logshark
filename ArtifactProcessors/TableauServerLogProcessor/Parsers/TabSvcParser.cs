﻿using LogParsers.Base;
using LogParsers.Base.Helpers;
using LogParsers.Base.Parsers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Logshark.ArtifactProcessors.TableauServerLogProcessor.Parsers
{
    /// <summary>
    /// Parses TabSvc logs to JSON.
    /// </summary>
    public sealed class TabSvcParser : AbstractMultiLineRegexParser, IParser
    {
        private static readonly string collectionName = ParserConstants.TabSvcCollectionName;
        private static readonly IList<string> indexNames = new List<string> { "sev" };
        private static readonly CollectionSchema collectionSchema = ParserUtil.CreateCollectionSchema(collectionName, indexNames);

        private readonly IList<Regex> regexes = new List<Regex>
            {
                // 10.5+ TSM-style
                new Regex(@"^(?<ts>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})\s
                         (?<ts_offset>.+?)\s
                         (?<thread>.*?)\s
                         :\s
                         (?<sev>[A-Z]+)(\s+)
                         (?<class>.*?)\s-\s
                         (?<message>(.|\n)*)",
                    RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled),
                // 9.0+ Classic-style
                new Regex(@"^
                            (?<ts>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})\s
                            (?<ts_offset>.*?)_
                            (?<sev>[A-Z]+)_
                            server=(?<address>.*?):
                            (?<hostname>.*?)_
                            service=(?<service>.*?):_
                            session=(?<sess>.*?)_
                            pid=(?<pid>\d*)_
                            tid=(?<tid>.*?)_
                            logger=(?<logger>.*?)_
                            user=(?<user>.*?)_
                            session=_
                            request=(?<req>.*?)_
                            message=(?<message>(.|\n)*)",
                    RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled)
            };

        private readonly IList<Regex> lineDelimiterRegexes = new List<Regex>
            {
                new Regex(@"^\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3}\s") // DateTime string
            };

        protected override IList<Regex> Regexes
        {
            get { return regexes; }
        }

        protected override IList<Regex> LineDelimiterRegexes
        {
            get { return lineDelimiterRegexes; }
        }

        public override CollectionSchema CollectionSchema
        {
            get { return collectionSchema; }
        }

        public TabSvcParser()
        {
        }

        public TabSvcParser(LogFileContext fileContext)
            : base(fileContext)
        {
        }
    }
}