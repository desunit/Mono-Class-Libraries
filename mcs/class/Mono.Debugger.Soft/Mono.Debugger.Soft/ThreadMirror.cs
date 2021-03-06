using System;
using System.Threading;

namespace Mono.Debugger.Soft
{
	public class ThreadMirror : ObjectMirror
	{
		string name;

		internal ThreadMirror (VirtualMachine vm, long id) : base (vm, id) {
		}

		// FIXME: Cache, invalidate when the thread/runtime is resumed
		public StackFrame[] GetFrames () {
			FrameInfo[] frame_info = vm.conn.Thread_GetFrameInfo (id, 0, -1);

			StackFrame[] frames = new StackFrame [frame_info.Length];
			for (int i = 0; i < frame_info.Length; ++i) {
				FrameInfo info = (FrameInfo)frame_info [i];
				MethodMirror method = vm.GetMethod (info.method);
				frames [i] = new StackFrame (vm, info.id, this, method, info.il_offset, info.flags);
			}

			return frames;
	    }

		public string Name {
			get {
				if (name == null)
					name = vm.conn.Thread_GetName (id);
				return name;
			}
	    }

		public new long Id {
			get {
				return id;
			}
		}

		public ThreadState ThreadState {
			get {
				return (ThreadState)vm.conn.Thread_GetState (id);
			}
		}

		public bool IsThreadPoolThread {
			get {
				ThreadInfo info = vm.conn.Thread_GetInfo (id);

				return info.is_thread_pool;
			}
		}
    }
}
