//------------------------------------------------------------------------------
// 
// System.Environment.cs 
//
// Copyright (C) 2001 Moonlight Enterprises, All Rights Reserved
// 
// Author:         Jim Richardson, develop@wtfo-guru.com
//                 Dan Lewis (dihlewis@yahoo.co.uk)
// Created:        Saturday, August 11, 2001 
//
//------------------------------------------------------------------------------
//
// Copyright (C) 2004-2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.IO;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Runtime.InteropServices;

namespace System
{
	public partial class Environment
	{
		
		
		/// <summary>
		/// Gets or sets the exit code of this process
		/// </summary>
		public extern static int ExitCode
		{	
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		set;
		}
		
		static public extern bool HasShutdownStarted
		{
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;
		}

		/// <summary>
		/// Gets the name of the local computer
		/// </summary>
		public extern static string MachineName {
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		[EnvironmentPermission (SecurityAction.Demand, Read="COMPUTERNAME")]
		[SecurityPermission (SecurityAction.Demand, UnmanagedCode=true)]
		get;
		}

		/// <summary>
		/// Gets the standard new line value
		/// </summary>
		public extern static string NewLine {
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;
		}
		
		internal static extern PlatformID Platform {
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;
		}
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal static extern string GetOSVersionString ();

		/// <summary>
		/// Get the number of milliseconds that have elapsed since the system was booted
		/// </summary>
		public extern static int TickCount {
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;
		}

		/// <summary>
		/// Get the user name of current process is running under
		/// </summary>
		public extern static string UserName
		{
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		[EnvironmentPermission (SecurityAction.Demand, Read="USERNAME;USER")]
		get;
		}
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		[SecurityPermission (SecurityAction.Demand, UnmanagedCode=true)]
		public extern static void Exit (int exitCode);

		/// <summary>
		/// Return an array of the command line arguments of the current process
		/// </summary>
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		[EnvironmentPermissionAttribute (SecurityAction.Demand, Read = "PATH")]
		public extern static string[] GetCommandLineArgs ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal extern static string internalGetEnvironmentVariable (string variable);
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		private extern static string GetWindowsFolderPath (int folder);
		
#if !NET_2_1
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		private static extern void internalBroadcastSettingChange ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal static extern void InternalSetEnvironmentVariable (string variable, string value);
#endif
		
		public static extern int ProcessorCount {
		[EnvironmentPermission (SecurityAction.Demand, Read="NUMBER_OF_PROCESSORS")]
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		get;			
		}
#pragma warning restore 169
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal extern static string internalGetGacPath ();

		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		private extern static string [] GetLogicalDrivesInternal ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		private extern static string [] GetEnvironmentVariableNames ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal extern static string GetMachineConfigPath ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal extern static string internalGetHome ();
		
		[MethodImplAttribute (MethodImplOptions.InternalCall)]
		internal extern static int GetPageSize ();

	}
}
