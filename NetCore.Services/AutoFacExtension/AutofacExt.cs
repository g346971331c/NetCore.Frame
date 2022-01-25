using Autofac;
using Microsoft.Extensions.Caching.Memory;
using NetCore.Infrastructure.cache;
using NetCore.IServices;
using NetCore.Repository;
using NetCore.Repository.Interface;
using NetCore.Services.BaseInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetCore.Services.AutoFacExtension
{
    public static class AutofacExt
    {
        public static void InitAutoFac(ContainerBuilder builder)
        {
            //仓储类需单独注入
            builder.RegisterGeneric(typeof(BaseRespository<>)).As(typeof(IRespository<>));

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            //builder.RegisterType(typeof(MemoryCache)).As(typeof(IMemoryCache));
            builder.RegisterType(typeof(CacheContext)).As(typeof(ICacheContext));
            ////要注入的程序集
            //Assembly ins = Assembly.Load("NetCore.Infrastructure");
            //builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes());
             


            Assembly services = Assembly.Load("NetCore.Services");
            Assembly iServices = Assembly.Load("NetCore.IServices");
            builder.RegisterAssemblyTypes(services, iServices).AsImplementedInterfaces();




            #region 以下方法废弃

            //var arr = Assembly.GetExecutingAssembly(); //当前正在运行的程序集，Services
            //var bbb = arr.GetTypes();

            //var direcotry = AppDomain.CurrentDomain.BaseDirectory;
            //string[] allDll = Directory.GetFiles(direcotry, "NetCore.*.dll");
            //for (int i = 0; i < allDll.Length; i++)
            //{
            //    Assembly a1 = Assembly.LoadFile(allDll[i]);
            //    if (a1.FullName.Contains("NetCore.Frame"))
            //        continue;
            //    //var interFaceList = a1.GetTypes().Where(a => a.FullName.Contains("NetCore.IServices")).ToList();
            //    //if (interFaceList.Count > 0)
            //    //{
            //    //    var iserviceAndServiceList = from a in arr.GetTypes()
            //    //                                 join b in interFaceList
            //    //                                 on a.Name equals b.Name.TrimStart('I')
            //    //                                 select a;
            //    //    foreach (var item in iserviceAndServiceList)
            //    //    {
            //    //        //根据类 找接口
            //    //        var interfaceType = interFaceList.First(i => i.Name.Equals("I" + item.Name));
            //    //        //找到类对应的接口，则注册
            //    //        if (interfaceType != null)
            //    //        {
            //    //            //  builder.RegisterType(item).As(interfaceType);
            //自动注入报错
            //    //            builder.RegisterType(item).As(interfaceType);
            //    //        }

            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    //  
            //    //}
            //    builder.RegisterAssemblyTypes(a1);

            //}
            //注入具体类和接口可行
            // builder.RegisterType(typeof(LoginServices)).As(typeof(ILoginServices));
            #endregion

        }
    }
}
