using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternExamples.Memento_Pattern
{
	internal class Document
	{
		internal string Content { get; set; }
		private readonly DocumentKeeper _documentKeeper;
		internal Document()
		{
			_documentKeeper = new DocumentKeeper();
		}
		internal DocumentState UserSaves()
		{
			var state = new DocumentState();
			state.SavedContent = Content;
			return state;
		}
		public void Save()
		{
			var state = UserSaves();
			_documentKeeper.SaveDocument(state);
		}
		public void Undo()
		{
			var currentState = _documentKeeper.RestoreDocument();
			Content=currentState.SavedContent;
		}
	}
	internal class DocumentState
	{
		internal string SavedContent { get; set; }

	}
	internal class DocumentKeeper
	{
		 private Stack<DocumentState> _stack = new Stack<DocumentState>();
		public void SaveDocument(DocumentState state)
		{
			_stack.Push(state);
		}
		public DocumentState RestoreDocument()
		{
			if (_stack.Count > 1)
			{
				_stack.Pop();
				return _stack.Peek();
			}
			else if(_stack.Count == 1)
			{
				return _stack.Peek();
			}
			else
			{
				throw new InvalidOperationException(" Cant undo with with nothing saved.");
			}
		}

	}
}
