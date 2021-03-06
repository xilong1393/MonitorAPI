﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorAPI.Service
{
    public class ServiceFactory
    {
        private static readonly object padlock = new object();
        private static UserService userService;
        private static LogService logService;
        private static ClassroomService classroomService;
        private static ClassroomGroupService classroomGroupService;
        private static OperationService operationService;
        private static TestCourseService testCourseService;
        public static UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    lock (padlock)
                    {
                        if (userService == null)
                        {
                            userService = new UserService();
                        }
                    }
                }
                return userService;
            }
        }

        public static LogService LogService
        {
            get
            {
                if (logService == null)
                {
                    lock (padlock)
                    {
                        if (logService == null)
                        {
                            logService = new LogService();
                        }
                    }
                }
                return logService;
            }
        }

        public static ClassroomService ClassroomService
        {
            get
            {
                if (classroomService == null)
                {
                    lock (padlock)
                    {
                        if (classroomService == null)
                        {
                            classroomService = new ClassroomService();
                        }
                    }
                }
                return classroomService;
            }
        }

        public static ClassroomGroupService ClassroomGroupService
        {
            get
            {
                if (classroomGroupService == null)
                {
                    lock (padlock)
                    {
                        if (classroomGroupService == null)
                        {
                            classroomGroupService = new ClassroomGroupService();
                        }
                    }
                }
                return classroomGroupService;
            }
        }

        public static OperationService OperationService
        {
            get
            {
                if (operationService == null)
                {
                    lock (padlock)
                    {
                        if (operationService == null)
                        {
                            operationService = new OperationService();
                        }
                    }
                }
                return operationService;
            }
        }

        public static TestCourseService TestCourseService
        {
            get
            {
                if (testCourseService == null)
                {
                    lock (padlock)
                    {
                        if (testCourseService == null)
                        {
                            testCourseService = new TestCourseService();
                        }
                    }
                }
                return testCourseService;
            }
        }
    }
}