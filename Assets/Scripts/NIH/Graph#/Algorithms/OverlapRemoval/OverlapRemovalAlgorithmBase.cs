using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Windows;
using Unity.Mathematics;
using Unity.Tiny;
using static Unity.Mathematics.math;

namespace GraphSharp.Algorithms.OverlapRemoval
{
	public abstract class OverlapRemovalAlgorithmBase<TObject, TParam> : AlgorithmBase, IOverlapRemovalAlgorithm<TObject, TParam>
		where TObject : class
		where TParam : IOverlapRemovalParameters
	{
		protected IDictionary<TObject, Rect> originalRectangles;
		public IDictionary<TObject, Rect> Rectangles
		{
			get { return originalRectangles; }
		}

		public TParam Parameters { get; private set; }

		public IOverlapRemovalParameters GetParameters()
		{
			return Parameters;
		}

		protected List<RectangleWrapper<TObject>> wrappedRectangles;


		public OverlapRemovalAlgorithmBase( IDictionary<TObject, Rect> rectangles, TParam parameters )
		{
			//eredeti t�glalapok list�ja
			originalRectangles = rectangles;

			//wrapping the old rectangles, to remember which one belongs to which object
			wrappedRectangles = new List<RectangleWrapper<TObject>>();
			int i = 0;
			foreach ( var kvpRect in rectangles )
			{
				wrappedRectangles.Insert( i, new RectangleWrapper<TObject>( kvpRect.Value, kvpRect.Key ) );
				i++;
			}

			Parameters = parameters;
		}

		protected sealed override void InternalCompute()
		{
			AddGaps();

			RemoveOverlap();

			RemoveGaps();

			foreach ( var r in wrappedRectangles )
				originalRectangles[r.Id] = r.Rectangle;
		}

		protected virtual void AddGaps()
		{
			foreach ( var r in wrappedRectangles )
			{
				r.Rectangle.width += Parameters.HorizontalGap;
				r.Rectangle.height += Parameters.VerticalGap;
				r.Rectangle.x -= Parameters.HorizontalGap / 2;
				r.Rectangle.y -= Parameters.VerticalGap / 2;
			}
		}

		protected virtual void RemoveGaps()
		{
			foreach ( var r in wrappedRectangles )
			{
				r.Rectangle.width -= Parameters.HorizontalGap;
				r.Rectangle.height -= Parameters.VerticalGap;
				r.Rectangle.x += Parameters.HorizontalGap / 2;
				r.Rectangle.y += Parameters.VerticalGap / 2;
			}
		}

		protected abstract void RemoveOverlap();
	}
}