using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.Particles;
using Psim.ModelComponents;
using System;

namespace PsimUnitTests
{
	[TestClass]
	public class CellTests
	{
		[TestMethod]
		public void TestCell()
		{
			Phonon p1 = new Phonon(1);
			Phonon p2 = new Phonon(-1);
			Cell c = new Cell(10, 10);

			c.AddPhonon(p1);
			Assert.AreEqual(c.Phonons.Count, 1);
			c.AddIncPhonon(p2);
			c.MergeIncPhonons();
			Assert.AreEqual(c.Phonons.Count, 2);
		}

		[TestMethod]
		public void TestHandlePhonons()
        {
			Phonon p1 = new Phonon(1);
			Cell c = new Cell(10, 10);

			p1.SetDirection(1, 1);
			ISurface s = c.GetSurface(SurfaceLocation.right);
			s.HandlePhonon(p1);
			p1.GetDirection(out double dx, out double dy);
			Assert.AreEqual(dx, -1);
			Assert.AreEqual(dy, 1);

			s = c.GetSurface(SurfaceLocation.top);
			s.HandlePhonon(p1);
			p1.GetDirection(out dx, out dy);
			Assert.AreEqual(dx, -1);
			Assert.AreEqual(dy, -1);
		}
	}
}
