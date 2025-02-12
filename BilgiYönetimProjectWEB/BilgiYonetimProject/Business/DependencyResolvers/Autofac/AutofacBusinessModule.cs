using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Visitor Service and Dal
            builder.RegisterType<VisitorManager>().As<IVisitorService>().SingleInstance();
            builder.RegisterType<EfVisitorDal>().As<IVisitorDal>().SingleInstance();

            // Dealer Service and Dal
            builder.RegisterType<DealerManager>().As<IDealerService>().SingleInstance();
            builder.RegisterType<EfDealerDal>().As<IDealerDal>().SingleInstance();

            // DealerPoint Service and Dal
            builder.RegisterType<DealerPointManager>().As<IDealerPointService>().SingleInstance();
            builder.RegisterType<EfDealerPointDal>().As<IDealerPointDal>().SingleInstance();

            // CarModel Service and Dal
            builder.RegisterType<CarModelManager>().As<ICarModelService>().SingleInstance();
            builder.RegisterType<EfCarModelDal>().As<ICarModelDal>().SingleInstance();

            // Admin Service and Dal
            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().SingleInstance();





            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<EfSurveyDal>().As<ISurveyDal>().SingleInstance();
            builder.RegisterType<SurveyManager>().As<ISurveyService>().SingleInstance();

            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>().SingleInstance();
            builder.RegisterType<QuestionManager>().As<IQuestionService>().SingleInstance();

            builder.RegisterType<EfQuestionGroupDal>().As<IQuestionGroupDal>().SingleInstance();
            builder.RegisterType<QuestionGroupManager>().As<IQuestionGroupService>().SingleInstance();

            builder.RegisterType<EfProcessDal>().As<IProcessDal>().SingleInstance();
            builder.RegisterType<ProcessManager>().As<IProcessService>().SingleInstance();

            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();

            builder.RegisterType<EfAnswerDal>().As<IAnswerDal>().SingleInstance();
            builder.RegisterType<AnswerManager>().As<IAnswerService>().SingleInstance();
         
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
           
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
