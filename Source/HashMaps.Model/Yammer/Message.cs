using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Model.Yammer
{
    public class Count
    {
        public int messages { get; set; }
        public int groups { get; set; }
        public int topics { get; set; }
        public int uploaded_files { get; set; }
        public int users { get; set; }
        public int pages { get; set; }
        public int praises { get; set; }
    }

    public class ThreadedExtended
    {
    }

    public class Body
    {
        public string parsed { get; set; }
        public string plain { get; set; }
        public string rich { get; set; }
        public List<string> urls { get; set; }
    }

    public class LikedBy
    {
        public int count { get; set; }
        public List<object> names { get; set; }
    }

    public class YammerMessage
    {
        public int id { get; set; }
        public int sender_id { get; set; }
        public object replied_to_id { get; set; }
        public string created_at { get; set; }
        public int network_id { get; set; }
        public string message_type { get; set; }
        public string sender_type { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public int group_id { get; set; }
        public Body body { get; set; }
        public int thread_id { get; set; }
        public string client_type { get; set; }
        public string client_url { get; set; }
        public bool system_message { get; set; }
        public bool direct_message { get; set; }
        public object chat_client_sequence { get; set; }
        public string content_excerpt { get; set; }
        public string language { get; set; }
        public List<object> notified_user_ids { get; set; }
        public string privacy { get; set; }
        public List<object> attachments { get; set; }
        public LikedBy liked_by { get; set; }
    }

    public class Stats
    {
        public int following { get; set; }
        public int followers { get; set; }
        public int updates { get; set; }
        public int? shares { get; set; }
        public int? first_reply_id { get; set; }
        public string first_reply_at { get; set; }
        public int? latest_reply_id { get; set; }
        public string latest_reply_at { get; set; }
    }

    public class Topic
    {
        public int id { get; set; }
        public string type { get; set; }
    }

    public class Reference
    {
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public string state { get; set; }
        public string full_name { get; set; }
        public string job_title { get; set; }
        public string mugshot_url { get; set; }
        public string mugshot_url_template { get; set; }
        public string activated_at { get; set; }
        public Stats stats { get; set; }
        public int? thread_starter_id { get; set; }
        public int? group_id { get; set; }
        public List<Topic> topics { get; set; }
        public string privacy { get; set; }
        public bool? direct_message { get; set; }
        public bool? has_attachments { get; set; }
        public string description { get; set; }
        public string mugshot_id { get; set; }
        public string show_in_directory { get; set; }
        public object office365_url { get; set; }
        public string created_at { get; set; }
        public string normalized_name { get; set; }
        public string permalink { get; set; }
    }

    public class Meta
    {
        public int requested_poll_interval { get; set; }
        public object last_seen_message_id { get; set; }
        public int current_user_id { get; set; }
        public List<int> liked_message_ids { get; set; }
        public List<object> followed_references { get; set; }
        public List<object> ymodules { get; set; }
        public object newest_message_details { get; set; }
    }

    public class Messages
    {
        public ThreadedExtended threaded_extended { get; set; }
        public List<YammerMessage> messages { get; set; }
        public List<Reference> references { get; set; }
        public Meta meta { get; set; }
    }

    public class Topic2
    {
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string normalized_name { get; set; }
        public string permalink { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public List<object> references { get; set; }
        public List<object> expert_referents { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int size { get; set; }
        public string thumbnail_url { get; set; }
    }

    public class LatestVersion
    {
        public int id { get; set; }
        public int file_id { get; set; }
        public string content_type { get; set; }
        public int size { get; set; }
        public int uploader_id { get; set; }
        public string created_at { get; set; }
        public string path { get; set; }
        public string download_url { get; set; }
        public string thumbnail_url { get; set; }
        public string preview_url { get; set; }
        public string large_preview_url { get; set; }
        public string streaming_url { get; set; }
        public string revert_url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string scaled_url { get; set; }
        public string thumbnail_path { get; set; }
        public string preview_path { get; set; }
        public string large_preview_path { get; set; }
    }

    public class Stats2
    {
        public int followers { get; set; }
    }

    public class File
    {
        public string url { get; set; }
        public int size { get; set; }
    }

    public class UploadedFile
    {
        public int id { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string content_type { get; set; }
        public string content_class { get; set; }
        public string created_at { get; set; }
        public int owner_id { get; set; }
        public string owner_type { get; set; }
        public bool official { get; set; }
        public string small_icon_url { get; set; }
        public string large_icon_url { get; set; }
        public string download_url { get; set; }
        public string thumbnail_url { get; set; }
        public string preview_url { get; set; }
        public string large_preview_url { get; set; }
        public int size { get; set; }
        public string last_uploaded_at { get; set; }
        public int last_uploaded_by_id { get; set; }
        public string last_uploaded_by_type { get; set; }
        public object uuid { get; set; }
        public bool? transcoded { get; set; }
        public string streaming_url { get; set; }
        public string path { get; set; }
        public int y_id { get; set; }
        public string overlay_url { get; set; }
        public string privacy { get; set; }
        public int? group_id { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string scaled_url { get; set; }
        public Image image { get; set; }
        public LatestVersion latest_version { get; set; }
        public Stats2 stats { get; set; }
        public File file { get; set; }
    }

    public class RootObject
    {
        public Count count { get; set; }
        public Messages messages { get; set; }
        public List<object> groups { get; set; }
        public List<Topic2> topics { get; set; }
        public List<UploadedFile> uploaded_files { get; set; }
        public List<object> users { get; set; }
        public List<object> pages { get; set; }
        public string search_uuid { get; set; }
    }
}
