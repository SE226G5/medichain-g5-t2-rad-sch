using RadiologyClinic.src;
using RadiologyClinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiologyClinic.Tests
{
    

        [TestFixture]
        public class RadiationDoseCalculatorTests
        {
            private RadiationDoseCalculator _calculator;
            private RadiationDoseCalculatorRefactored _refactored;

            [SetUp]
            public void Setup()
            {
                _calculator = new RadiationDoseCalculator();
                _refactored = new RadiationDoseCalculatorRefactored();
            }

            // ===== Original Method Tests =====

            [Test]
            public void DetermineRadiationDose_PregnantPatient_ReturnsScanNotAllowed()
            {
                string result = _calculator.DetermineRadiationDose("CT", 25, 65, true);
                Assert.That(result,Is.EqualTo("Scan not allowed: patient is pregnant"));
            }

            [Test]
            public void DetermineRadiationDose_CT_PediatricLightweight_ReturnsLowDose20()
            {
                string result = _calculator.DetermineRadiationDose("CT", 10, 30, false);
                Assert.That(result,Is.EqualTo("CT dose: Low (pediatric lightweight protocol) - 20 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_CT_PediatricStandard_ReturnsLowDose30()
            {
                string result = _calculator.DetermineRadiationDose("CT", 15, 50, false);
                Assert.That(result,Is.EqualTo("CT dose: Low (pediatric standard protocol) - 30 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_CT_ObeseAdult_ReturnsHighDose80()
            {
                string result = _calculator.DetermineRadiationDose("CT", 40, 120, false);
                Assert.That(result,Is.EqualTo("CT dose: High (obese adult protocol) - 80 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_CT_StandardAdult_ReturnsStandardDose50()
            {
                string result = _calculator.DetermineRadiationDose("CT", 35, 75, false);
                Assert.That(result,Is.EqualTo("CT dose: Standard (adult protocol) - 50 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_XRAY_PediatricPatient_ReturnsMinimalDose()
            {
                string result = _calculator.DetermineRadiationDose("XRAY", 8, 25, false);
                Assert.That(result,Is.EqualTo("X-Ray dose: Minimal (pediatric protocol) - 0.1 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_XRAY_AdultPatient_ReturnsStandardDose()
            {
                string result = _calculator.DetermineRadiationDose("XRAY", 30, 70, false);
                Assert.That(result,Is.EqualTo("X-Ray dose: Standard (adult protocol) - 0.2 mSv"));
            }

            [Test]
            public void DetermineRadiationDose_UnknownScanType_ReturnsUnknownMessage()
            {
                string result = _calculator.DetermineRadiationDose("MRI", 30, 70, false);
                Assert.That(result,Is.EqualTo("Unknown scan type: no dose assigned"));
            }

            // ===== Refactored Method Tests (same expected results) =====

            [Test]
            public void Refactored_PregnantPatient_ReturnsScanNotAllowed()
            {
                string result = _refactored.DetermineRadiationDose("CT", 25, 65, true);
                Assert.That(result,Is.EqualTo("Scan not allowed: patient is pregnant"));
            }

            [Test]
            public void Refactored_CT_ObeseAdult_ReturnsHighDose80()
            {
                string result = _refactored.DetermineRadiationDose("CT", 40, 120, false);
                Assert.That(result,Is.EqualTo("CT dose: High (obese adult protocol) - 80 mSv"));
            }

            [Test]
            public void Refactored_XRAY_AdultPatient_ReturnsStandardDose()
            {
                string result = _refactored.DetermineRadiationDose("XRAY", 30, 70, false);
                Assert.That(result,Is.EqualTo("X-Ray dose: Standard (adult protocol) - 0.2 mSv"));
            }
        }
    }


