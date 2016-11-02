﻿using MongoDB.Driver;
using ServiceStack.OrmLite;
using System.Collections.Generic;

namespace Logshark.PluginLib.Model
{
    public interface IPlugin
    {
        ISet<string> CollectionDependencies { get; }


        IDbConnectionFactory OutputDatabaseConnectionFactory { set; }
        IMongoDatabase MongoDatabase { set; }

        IPluginResponse Execute(IPluginRequest pluginRequest);
    }
}