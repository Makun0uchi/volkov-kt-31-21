using VolkoVladislavKT_31_21.Interfaces.GradeInterfaces;
using VolkoVladislavKT_31_21.Interfaces.GroupInterfaces;
using VolkoVladislavKT_31_21.Interfaces.StudentInterfaces;
using VolkoVladislavKT_31_21.Interfaces.SubjectInterfaces;

namespace VolkoVladislavKT_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IGroupService, GroupService>();

            return services;
        }
    }
}
