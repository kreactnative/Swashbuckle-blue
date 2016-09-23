﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swashbuckle.Annotations;
using Swashbuckle.Annotations.AttributeTags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assert = NUnit.Framework.Assert;

namespace Swashbuckle.Tests
{
    [TestClass]
    public class DataAnnotationsTests
    {
        private RequiredFieldTestObject m_TestObject;

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "StringType")]
        public void TestRequiredFieldStringTypeForDefaultNullValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                GuidType = Guid.NewGuid(),
                IntegerType = 10,
                NullableDecimalType = 20,
                NullableIntegerType = 20,
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: StringType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "StringType")]
        public void TestRequiredFieldStringTypeForExplicitNullValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                GuidType = Guid.NewGuid(),
                IntegerType = 10,
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = null
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: StringType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        // [PaymentsExpectedException(typeof(ArgumentNullException), "StringType")]
        public void TestRequiredFieldStringTypeForEmptyValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                GuidType = Guid.NewGuid(),
                IntegerType = 10,
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = string.Empty
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: StringType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "IntegerType")]
        public void TestRequiredFieldIntegerTypeForDefaultValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                GuidType = Guid.NewGuid(),
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: IntegerType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        // [PaymentsExpectedException(typeof(ArgumentNullException), "IntegerType")]
        public void TestRequiredFieldIntegerTypeForExplicitDefaultValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 0,
                GuidType = Guid.NewGuid(),
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: IntegerType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestRequiredFieldDecimalTypeForDefaultValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: DecimalType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "DecimalType is null. Payload={\"StringType\":\"Payments\",\"IntegerType\":10,\"DecimalType\":0.0,\"GuidType\":\"7907ab1f-bab5-489d-b557-7436228d99a2\",\"NullableIntegerType\":20,\"NullableDecimalType\":20.0,\"NullableGuidType\":null}")]
        public void TestRequiredFieldDecimalTypeForExplicitDefaultValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 0,
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: DecimalType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "GuidType")]
        public void TestRequiredFieldGuidTypeForDefaultValues()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 10,
                NullableDecimalType = 20,
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: GuidType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "NullableIntegerType")]
        public void TestRequiredFieldNullableIntegerType()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableDecimalType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: NullableIntegerType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "NullableDecimalType")]
        public void TestRequiredFieldNullableDecimalType()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableIntegerType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: NullableDecimalType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "NullableGuidType")]
        public void TestRequiredFieldNullableGuidType()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableIntegerType = 20,
                NullableDecimalType = 20,
                StringType = "Payments",
            };

            try
            {
                SwashValidator.Validate(m_TestObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: NullableGuidType is null".AppendJson(m_TestObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestRequiredFieldHappyPath()
        {
            m_TestObject = new RequiredFieldTestObject()
            {
                DecimalType = 10,
                IntegerType = 10,
                GuidType = Guid.NewGuid(),
                NullableIntegerType = 20,
                NullableDecimalType = 20,
                StringType = "Payments",
                NullableGuidType = Guid.NewGuid()
            };

            Assert.IsTrue(SwashValidator.Validate(m_TestObject));
        }

        [TestMethod]
        //[PaymentsExpectedException(typeof(ArgumentNullException), "BaseStringType")]
        public void TestRequiredFieldForBaseClassProperties()
        {
            RequiredFieldBase derivedObject = new RequiredFieldDerived()
            {
                DerivedIntegerType = 10,
                DerivedStringType = "Payments"
            };

            try
            {
                SwashValidator.Validate(derivedObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: BaseStringType is null".AppendJson(derivedObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestRequiredFieldForDerivedClassProperties()
        {
            RequiredFieldDerived derivedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments"
            };

            try
            {
                SwashValidator.Validate(derivedObject);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Value cannot be null.\r\nParameter name: DerivedIntegerType is null".AppendJson(derivedObject));
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void TestTryValidateRequiredFieldForDerivedClassProperties()
        {
            var derivedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments"
            };

            var msg = string.Empty;

            var status = SwashValidator.TryValidate(derivedObject, out msg);
            Assert.IsFalse(status);
            Assert.AreEqual(msg, "Value cannot be null.\r\nParameter name: DerivedIntegerType is null".AppendJson(derivedObject));
        }

        [TestMethod]
        public void TestSensitiveFields()
        {
            var derivedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments",
                SensitiveString = "this should be null",
                SensitiveInt = 88888
            };

            var msg = string.Empty;

            var status = SwashValidator.TryValidate(derivedObject, out msg);
            Assert.IsFalse(status);

            Assert.IsFalse(msg.Contains("this should be null"));
            Assert.IsFalse(msg.Contains("88888"));
        }

        [TestMethod]
        public void TestTryValidateRequiredFieldNoOutputJson()
        {
            var derivedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments"
            };

            var msg = string.Empty;

            var status = SwashValidator.TryValidate(derivedObject, out msg, false);
            Assert.IsFalse(status);
            Assert.AreEqual(msg, "Value cannot be null.\r\nParameter name: DerivedIntegerType is null");
        }

        [TestMethod]
        public void TestRequiredFieldHappyPathForInheritedClass()
        {
            RequiredFieldBase inheritedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments",
                DerivedIntegerType = 10
            };

            Assert.IsTrue(SwashValidator.Validate(inheritedObject));
        }

        [TestMethod]
        public void TestTryValidateRequiredFieldHappyPathForInheritedClass()
        {
            var msg = "";
            RequiredFieldBase inheritedObject = new RequiredFieldDerived()
            {
                BaseStringType = "Payments",
                DerivedIntegerType = 10
            };

            var res = SwashValidator.TryValidate(inheritedObject, out msg);
            Assert.IsTrue(res);
            Assert.IsNull(msg);
        }

        [TestMethod]
        public void MinLengthTest()
        {
            var obj1 = new MinLengthTestClass()
            {
                MinLengthOf3 = "1234",
                anotherStr = "123"
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));

            try
            {
                var obj2 = new MinLengthTestClass()
                {
                    MinLengthOf3 = "12" //not long enough
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("has length 2.  Minlength is 3"));
            }
        }

        [TestMethod]
        public void MaxLengthTest()
        {
            var obj1 = new MaxLengthTestClass()
            {
                MaxLengthOf3 = "14"
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));

            try
            {
                var obj2 = new MaxLengthTestClass()
                {
                    MaxLengthOf3 = "12444" //too long
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("has length 5.  Maxlength is 3"));
            }
        }

        #region RegEx Validation

        [TestMethod]
        public void TestRegExCountry()
        {
            try
            {
                //Valid value
                var obj = new RegExCountyTestClass()
                {
                    Text = "US"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "PPP";
                SwashValidator.Validate(obj); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExCurrency()
        {
            try
            {
                //Valid value
                var obj = new RegExCurrencyTestClass()
                {
                    Text = "USD"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "OJY";
                SwashValidator.Validate(obj);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExRegion()
        {
            try
            {
                //Valid value
                var obj = new RegExRegionTestClass()
                {
                    Text = "EMEA"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "AAA";
                SwashValidator.Validate(obj);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExLanguage()
        {
            try
            {
                //Valid value
                var obj = new RegExLanguageTestClass()
                {
                    Text = "EN"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "XX";
                SwashValidator.Validate(obj);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExUrl()
        {
            try
            {
                //Valid value
                var obj = new RegExUrlTestClass()
                {
                    Text = "http://dell.com"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                obj.Text = "https://dell.com";
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "dell.com";
                SwashValidator.Validate(obj); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExEmail()
        {
            try
            {
                //Valid value
                var obj = new RegExEmailTestClass()
                {
                    Text = "test@test.com"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "test.com";
                SwashValidator.Validate(obj);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        [TestMethod]
        public void TestRegExIPAddress()
        {
            try
            {
                //Valid value
                var obj = new RegExIPAddressTestClass()
                {
                    Text = "168.0.2.456"
                };
                Assert.IsTrue(SwashValidator.Validate(obj));

                //Invalid Value
                obj.Text = "1098.3456.33.44";
                SwashValidator.Validate(obj);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("is invalid. Received value"));
            }
        }

        #endregion RegEx Validation

        [TestMethod]
        public void ObjectWithNestedClassNotRequired()
        {
            var obj1 = new SomeObjectWithNestedClassWithoutRequired()
            {
                SomethingElse = "something",
                ThisIsNotARequiredObj = null  //since this is not required this should not throw error
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));
        }

        [TestMethod]
        public void ObjectWithNestedClass()
        {
            var obj1 = new SomeObjectWithNestedClass()
            {
                SomethingElse = "something",
                ThisIsARequiredObj = null
            };

            try
            {
                SwashValidator.Validate(obj1);
                Assert.Fail(); // should not reach here
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains(" is null"));
            }
        }

        [TestMethod]
        public void StrLengthTest()
        {
            var obj1 = new StrLengthTestClass()
            {
                SomeString = "as"
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));

            try
            {
                var obj2 = new StrLengthTestClass()
                {
                    SomeString = "12234234234234" //too long
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("SomeString has length 14.  Maxlength is 3"));
            }
        }

        [TestMethod]
        public void StrLengthTest2()
        {
            var obj1 = new StrLengthTestClass2()
            {
                SomeString = "as44"
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));

            try
            {
                var obj2 = new StrLengthTestClass2()
                {
                    SomeString = "1" //too short
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("SomeString has length 1.  Minlength is 2"));
            }

            try
            {
                var obj2 = new StrLengthTestClass2()
                {
                    SomeString = "1324234234234234" //too long
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("SomeString has length 16.  Maxlength is 5"));
            }
        }

        [TestMethod]
        public void RangeTest()
        {
            var obj1 = new RangeTestClass()
            {
                SomeInt = 5
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));

            try
            {
                var obj2 = new RangeTestClass()
                {
                    SomeInt = 1
                };

                SwashValidator.Validate(obj2); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("SomeInt is invalid. Received value: 1"));
            }

            try
            {
                var obj3 = new RangeTestClass()
                {
                    SomeInt = 1123123
                };

                SwashValidator.Validate(obj3); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("SomeInt is invalid. Received value: 1123123, accepted values: 3 to 8000"));
            }
        }

        #region List Test cases

        /// <summary>
        /// Test Optioanl string list with value test.
        /// Test case 1 : Optional string list : With List<string> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void OptioanlStringListWithValueTest()
        {
            var obj1 = new ObjWithOptionalList()
            {
                OptionalStringCollection = new List<string>() { "Test" },
            };

            Assert.IsTrue(SwashValidator.Validate(obj1));
        }

        /// <summary>
        /// Optioanl string list with out value test.
        /// Test case 2 : Optional string list : WITHOUT List<string> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void OptioanlStringListWithOutValueTest()
        {
            var obj2 = new ObjWithOptionalList(); // Empty string list

            Assert.IsTrue(SwashValidator.Validate(obj2));
        }

        /// <summary>
        /// Requireds string list with value test.
        /// Test case 3 : Required string list : With List<string> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void RequiredStringListWithValueTest()
        {
            var obj3 = new ObjWithRequiredList()
            {
                RequiredStringCollection = new List<string>() { "Test" }
            };

            Assert.IsTrue(SwashValidator.Validate(obj3));
        }

        /// <summary>
        /// Requireds string list with out value test.
        /// Test case 4 : Required string list : WITHOUT List<string> - Expected reult : throw required exception
        /// </summary>
        [TestMethod]
        public void RequiredStringListWithOutValueTest()
        {
            try
            {
                var obj4 = new ObjWithRequiredList(); //empty string list test

                SwashValidator.Validate(obj4); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Parameter name: RequiredStringCollection is null"));
            }
        }

        /// <summary>
        /// Optioanls object list with value test.
        /// Test case 5 : Optional Complex type list : With list<Slot> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void OptioanlObjectListWithValueTest()
        {
            var obj5 = new ComplexTypeWithOptionalList()
            {
                OptionalObject = new List<slot>()
                {
                    new slot() {MyProperty1 = "value"}
                }
            };

            Assert.IsTrue(SwashValidator.Validate(obj5));
        }

        /// <summary>
        /// Optioanls object list with out value test.
        /// Test case 6 : Optional complext type list : WITHOUT list<Slot> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void OptioanlObjectListWithOutValueTest()
        {
            var obj6 = new ComplexTypeWithOptionalList(); // Empty object list

            Assert.IsTrue(SwashValidator.Validate(obj6));
        }

        /// <summary>
        /// Requireds the object list with value test.
        /// Test case 7 : Required complext type list : With list<Slot> - Expected reult : True
        /// </summary>
        [TestMethod]
        public void RequiredObjectListWithValueTest()
        {
            var obj7 = new ComplexTypeWithRequiredList
            {
                RequiredObject = new List<slot>()
                {
                    new slot() {MyProperty1 = "value"}
                }
            };

            Assert.IsTrue(SwashValidator.Validate(obj7));
        }

        /// <summary>
        /// Requireds the object list with out value test.
        /// Test case 8 : Required complext type list : WITHOUT list<Slot> - Expected reult : throw required exception
        /// </summary>
        [TestMethod]
        public void RequiredObjectListWithOutValueTest()
        {
            try
            {
                var obj8 = new ComplexTypeWithRequiredList(); //empty list test

                SwashValidator.Validate(obj8); //should throw exception
                Assert.Fail(); // should not reach here because empty string threw exception
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Parameter name: RequiredObject is null"));
            }
        }
    }

        #endregion List Test cases

    public class RequiredFieldTestObject
    {
        [Required]
        public string StringType { get; set; }

        [Required]
        public int IntegerType { get; set; }

        [Required]
        public decimal DecimalType { get; set; }

        [Required]
        public Guid GuidType { get; set; }

        [Required]
        public int? NullableIntegerType { get; set; }

        [Required]
        public decimal? NullableDecimalType { get; set; }

        [Required]
        public Guid? NullableGuidType { get; set; }
    }

    public class RequiredFieldBase
    {
        [Required]
        public string BaseStringType { get; set; }

        public int BaseIntegerType { get; set; }
    }

    public class RequiredFieldDerived : RequiredFieldBase
    {
        public string DerivedStringType { get; set; }

        [Required]
        public int DerivedIntegerType { get; set; }

        [SensitiveData]
        public string SensitiveString { get; set; }

        [SensitiveData]
        public int SensitiveInt { get; set; }
    }

    public class ObjWithOptionalList
    {
        public List<string> OptionalStringCollection { get; set; }
    }

    public class ObjWithRequiredList
    {
        [Required]
        public List<string> RequiredStringCollection { get; set; }
    }

    public class ComplexTypeWithRequiredList
    {
        [Required]
        public List<slot> RequiredObject { get; set; }
    }

    public class ComplexTypeWithOptionalList
    {
        public List<slot> OptionalObject { get; set; }
    }

    public class slot
    {
        public string MyProperty1 { get; set; }
    }

    public class MinLengthTestClass
    {
        [MinLength(3)]
        public string MinLengthOf3 { get; set; }

        public string anotherStr { get; set; }
    }

    public class MaxLengthTestClass
    {
        [MaxLength(3)]
        public string MaxLengthOf3 { get; set; }
    }

    public class StrLengthTestClass
    {
        [StringLength(3)]
        public string SomeString { get; set; }
    }

    public class StrLengthTestClass2
    {
        [StringLength(5, MinimumLength = 2)]
        public string SomeString { get; set; }
    }

    public class RangeTestClass
    {
        [Range(3, 8000)]
        public int SomeInt { get; set; }
    }

    public class RegExCountyTestClass
    {
        [RegEx(ValidationType.Country)]
        public string Text { get; set; }
    }

    public class RegExCurrencyTestClass
    {
        [RegEx(ValidationType.Currency)]
        public string Text { get; set; }
    }

    public class RegExEmailTestClass
    {
        [RegEx(ValidationType.Email)]
        public string Text { get; set; }
    }

    public class RegExIPAddressTestClass
    {
        [RegEx(ValidationType.IPAddress)]
        public string Text { get; set; }
    }

    public class RegExLanguageTestClass
    {
        [RegEx(ValidationType.Language)]
        public string Text { get; set; }
    }

    public class RegExRegionTestClass
    {
        [RegEx(ValidationType.Region)]
        public string Text { get; set; }
    }

    public class RegExUrlTestClass
    {
        [RegEx(ValidationType.Url)]
        public string Text { get; set; }
    }

    public class SomeObjectWithNestedClass
    {
        public string SomethingElse { get; set; }

        [Required]
        public slot ThisIsARequiredObj { get; set; }
    }

    public class SomeObjectWithNestedClassWithoutRequired
    {
        public string SomethingElse { get; set; }

        public slot ThisIsNotARequiredObj { get; set; }
    }
}