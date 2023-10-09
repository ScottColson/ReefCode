using System.Threading.Tasks;

namespace ReefCode.Reefi
{
    public interface ILightCommand
    {
        /// <summary>
        /// Resume lighting schedule
        /// </summary>
        void Resume();

        /// <summary>
        /// Resume lighting schedule
        /// </summary>
        Task ResumeAsync();

        /// <summary>
        /// Set to specific lighting profile
        /// </summary>
        /// <param name="profile"></param>
        void Set(IProfile profile);

        /// <summary>
        /// Set to specific lighting profile and intensity level.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="level"></param>
        void Set(IProfile profile, decimal level);

        /// <summary>
        /// Set to specific lighting profile
        /// </summary>
        /// <param name="profile"></param>
        Task SetAsync(IProfile profile);

        /// <summary>
        /// Set to specific lighting profile and intensity level.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="level"></param>
        Task SetAsync(IProfile profile, decimal level);
    }
}
