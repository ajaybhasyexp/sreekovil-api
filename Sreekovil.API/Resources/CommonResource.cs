using Microsoft.Extensions.Localization;

namespace Sreekovil.API.Resources
{
    public interface ICommonResource
    {

        string UnExpectedError { get; }

        string InvalidUser { get; }

        string BatchAssignmentExists { get; }

        string SaveSuccess { get; }

        string EntityAssignmentExists { get; }

        string GetString(string name);
    }

    public class CommonResource : ICommonResource
    {
        private readonly IStringLocalizer<CommonResource> _localizer;

        public CommonResource(IStringLocalizer<CommonResource> localizer) =>
            _localizer = localizer;


        public string UnExpectedError => GetString(nameof(UnExpectedError));

        public string InvalidUser => GetString(nameof(InvalidUser));

        public string BatchAssignmentExists => GetString(nameof(BatchAssignmentExists));

        public string SaveSuccess => GetString(nameof(SaveSuccess));

        public string EntityAssignmentExists => GetString(nameof(EntityAssignmentExists));


        public string GetString(string name) =>
            _localizer[name];
    }
}
