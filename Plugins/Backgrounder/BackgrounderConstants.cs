﻿using System.Collections.Generic;

namespace Logshark.Plugins.Backgrounder
{
    internal class BackgrounderConstants
    {
        public static readonly ISet<string> BackgrounderJobTypes = new HashSet<string>
        {
            "check_license_for_guest",
            "clean_sheet_image_cache",
            "cleanup_jobs",
            "delete_expired_refresh_tokens",
            "delete_expired_tickets",
            "delete_old_background_jobs",
            "delete_old_index_updates",
            "enqueue_ad_groups_sync",
            "generate_shared_view_static_images",
            "generate_sheet_image_for_view",
            "generate_snapshots",
            "generate_static_images",
            "generate_thumbnails",
            "increment_extracts",
            "list_extracts_for_tdfs_propagation",
            "list_extracts_for_tdfs_reaping",
            "mark_startup",
            "purge_dataengine_configurations",
            "purge_expired_wgsessions",
            "reap_audit_history_unused_records",
            "reap_auto_saves",
            "reap_extracts",
            "reap_repository_garbage_records",
            "reap_shared_views",
            "rebuild_search_indices",
            "reencrypt_keychains",
            "refresh_extracts",
            "sanitize_dataserver_workbooks",
            "single_subscription_notify",
            "subscription_notify",
            "sync_ad_group",
            "sync_search_index",
            "update_vertica_keychains"
        };

        public static readonly ISet<string> IgnoredClasses = new HashSet<string>
        {
            "com.tableausoftware.core.service.DependentServiceChecker",
            "com.tableausoftware.domain.solr.SolrPendingQueueProcessor"
        };

        public const string BackgrounderJavaCollectionName = "backgrounder_java";
        public const string BackgrounderJobRunnerClass = "com.tableausoftware.backgrounder.runner.BackgroundJobRunner";
        public const string SubscriptionRunnerClass = "com.tableausoftware.model.workgroup.service.subscriptions.SubscriptionRunner";
        public const string EmailHelperClass = "com.tableausoftware.model.workgroup.util.EmailHelper";
        public const string VqlSessionServiceClass = "com.tableausoftware.model.workgroup.service.VqlSessionService";
    }
}