using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using H2Stats.Data;

namespace H2Stats
{
    public static class PluginLoader
    {
        public static List<T> GetPlugins<T>(string filter)
        {
            string[] files = Directory.GetFiles(filter);
            List<T> tList = new List<T>();
            Debug.Assert(typeof(T).IsInterface);

            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (!type.IsClass || type.IsNotPublic) continue;
                        Type[] interfaces = type.GetInterfaces();

                        foreach(Type t in interfaces)
                        {
                            if (t == typeof(T))
                            {
                                object obj = Activator.CreateInstance(type);
                                T tInstance = (T)obj;
                                tList.Add(tInstance);
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

            return tList;

        }

        public static bool FillPluginLists(string filter, List<IGameViewerLauncher> gameViewers, List<ITotalsExport> totalsExporters,
            List<IGameExport> gameExporters)
        {
            string[] files = Directory.GetFiles(filter, "*.plugin.dll");

            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (!type.IsClass || type.IsNotPublic) continue;
                        Type[] interfaces = type.GetInterfaces();

                        foreach (Type t in interfaces)
                        {
                            if (t == typeof(IGameViewerLauncher))
                            {
                                object obj = Activator.CreateInstance(type);
                                gameViewers.Add((IGameViewerLauncher)obj);
                                break;
                            }

                            if (t == typeof (ITotalsExport))
                            {
                                totalsExporters.Add((ITotalsExport)Activator.CreateInstance(type));
                                break;
                            }

                            if (t == typeof(IGameExport))
                            {
                                gameExporters.Add((IGameExport)Activator.CreateInstance(type));
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }                
            }
            
            return true;          
        }

        
    }
}
