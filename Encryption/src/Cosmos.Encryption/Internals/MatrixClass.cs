using System;

namespace Cosmos.Encryption.Internals {
    /// <summary>
    /// A copy from GitHub project:
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Entities/MatrixClass.cs#L83:20
    /// 
    /// Classes Contained:
    /// 	MatrixClass (version 1.1)
    /// 	MatrixClassException
    /// 	Fraction (Version 2.0)
    /// 	FractionException
    /// Class name: MatrixClass
    /// Version: 1.1
    /// Class used: Fraction
    /// Developed by: Syed Mehroz Alam
    /// Email: smehrozalam@yahoo.com
    /// URL: Programming Home "http://www.geocities.com/smehrozalam/"
    /// 
    /// What's New in version 1.1
    /// 	*	Added DeterminentFast() method
    /// 	*	Added InverseFast() method
    /// 	*	renamed ConvertToString to (override) ToString()
    /// 	*	some minor bugs fixed
    /// 
    /// Constructors:
    /// 	( Fraction[,] ):	takes 2D Fractions array	
    /// 	( int[,] ):	takes 2D integer array, convert them to fractions	
    /// 	( double[,] ):	takes 2D double array, convert them to fractions
    /// 	( int Rows, int Cols )	initializes the dimensions, indexers may be used 
    /// 							to set individual elements' values
    /// 
    /// Properties:
    /// 	Rows: read only property to get the no. of rows in the current MatrixClass
    /// 	Cols: read only property to get the no. of columns in the current MatrixClass
    /// 
    /// Indexers:
    /// 	[i,j] = used to set/get elements in the form of a Fraction object
    /// 
    /// Public Methods (Description is given with respective methods' definitions)
    /// 	string ToString()
    /// 	MatrixClass Minor(MatrixClass, Row,Col)
    /// 	MultiplyRow( Row, Fraction )
    /// 	MultiplyRow( Row, integer )
    /// 	MultiplyRow( Row, double )
    /// 	AddRow( TargetRow, SecondRow, Multiple)
    /// 	InterchangeRow( Row1, Row2)
    /// 	MatrixClass Concatenate(MatrixClass1, MatrixClass2)
    /// 	Fraction Determinent()
    /// 	Fraction DeterminentFast()
    /// 	MatrixClass EchelonForm()
    /// 	MatrixClass ReducedEchelonForm()
    /// 	MatrixClass Inverse()
    /// 	MatrixClass InverseFast()
    /// 	MatrixClass Adjoint()
    /// 	MatrixClass Transpose()
    /// 	MatrixClass Duplicate()
    /// 	MatrixClass ScalarMatrixClass( Rows, Cols, K )
    /// 	MatrixClass IdentityMatrixClass( Rows, Cols )
    /// 	MatrixClass UnitMatrixClass(Rows, Cols)
    /// 	MatrixClass NullMatrixClass(Rows, Cols)
    /// 
    /// Private Methods
    /// 	Fraction GetElement(int iRow, int iCol)
    /// 	SetElement(int iRow, int iCol, Fraction value)
    /// 	Negate(MatrixClass)
    /// 	Add(MatrixClass1, MatrixClass2)
    /// 	Multiply(MatrixClass1, MatrixClass2)
    /// 	Multiply(MatrixClass1, Fraction)
    /// 	Multiply(MatrixClass1, integer)
    /// 
    /// Operators Overloaded Overloaded
    /// 	Unary: - (negate MatrixClass)
    /// 	Binary: 
    /// 		+,- for two matrices
    /// 		* for two matrices or one MatrixClass with integer or fraction or double
    /// 		/ for MatrixClass with integer or fraction or double
    /// </summary>
    internal class MatrixClass {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        int m_iRows;

        int m_iCols;
        Fraction[,] m_iElement;


        /// <summary>
        /// Constructors
        /// </summary>
        public MatrixClass(Fraction[,] elements) {
            m_iElement = elements;
            m_iRows = elements.GetLength(0);
            m_iCols = elements.GetLength(1);
        }

        public MatrixClass(int[,] elements) {
            m_iRows = elements.GetLength(0);
            m_iCols = elements.GetLength(1);
            ;
            m_iElement = new Fraction[m_iRows, m_iCols];
            for (int i = 0; i < elements.GetLength(0); i++) {
                for (int j = 0; j < elements.GetLength(1); j++) {
                    this[i, j] = new Fraction(elements[i, j]);
                }
            }
        }

        public MatrixClass(double[,] elements) {
            m_iRows = elements.GetLength(0);
            m_iCols = elements.GetLength(1);
            ;
            m_iElement = new Fraction[m_iRows, m_iCols];
            for (int i = 0; i < elements.GetLength(0); i++) {
                for (int j = 0; j < elements.GetLength(1); j++) {
                    this[i, j] = Fraction.ToFraction(elements[i, j]);
                }
            }
        }

        public MatrixClass(int iRows, int iCols) {
            m_iRows = iRows;
            m_iCols = iCols;
            m_iElement = new Fraction[iRows, iCols];
        }

        /// <summary>
        /// Properites
        /// </summary>
        public int Rows {
            get { return m_iRows; }
        }

        public int Cols {
            get { return m_iCols; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public Fraction this[int iRow, int iCol] // MatrixClass's index starts at 0,0
        {
            get { return GetElement(iRow, iCol); }
            set { SetElement(iRow, iCol, value); }
        }

        /// <summary>
        /// Internal functions for getting/setting values
        /// </summary>
        private Fraction GetElement(int iRow, int iCol) {
            if (iRow < 0 || iRow > Rows - 1 || iCol < 0 || iCol > Cols - 1)
                throw new MatrixClassException("Invalid index specified");
            return m_iElement[iRow, iCol];
        }

        private void SetElement(int iRow, int iCol, Fraction value) {
            if (iRow < 0 || iRow > Rows - 1 || iCol < 0 || iCol > Cols - 1)
                throw new MatrixClassException("Invalid index specified");
            m_iElement[iRow, iCol] = value.Duplicate();
        }


        /// <summary>
        /// The function returns the current MatrixClass object as a string
        /// </summary>
        public override string ToString() {
            string str = "";
            for (int i = 0; i < this.Rows; i++) {
                for (int j = 0; j < this.Cols; j++)
                    str += this[i, j] + "\t";
                str += "\n";
            }

            return str;
        }


        /// <summary>
        /// The function return the Minor of element[Row,Col] of a MatrixClass object 
        /// </summary>
        public static MatrixClass Minor(MatrixClass MatrixClass, int iRow, int iCol) {
            MatrixClass minor = new MatrixClass(MatrixClass.Rows - 1, MatrixClass.Cols - 1);
            int m = 0, n = 0;
            for (int i = 0; i < MatrixClass.Rows; i++) {
                if (i == iRow)
                    continue;
                n = 0;
                for (int j = 0; j < MatrixClass.Cols; j++) {
                    if (j == iCol)
                        continue;
                    minor[m, n] = MatrixClass[i, j];
                    n++;
                }

                m++;
            }

            return minor;
        }


        /// <summary>
        /// The function multiplies the given row of the current MatrixClass object by a Fraction 
        /// </summary>
        public void MultiplyRow(int iRow, Fraction frac) {
            for (int j = 0; j < this.Cols; j++) {
                this[iRow, j] *= frac;
                Fraction.ReduceFraction(this[iRow, j]);
            }
        }

        /// <summary>
        /// The function multiplies the given row of the current MatrixClass object by an integer
        /// </summary>
        public void MultiplyRow(int iRow, int iNo) {
            this.MultiplyRow(iRow, new Fraction(iNo));
        }

        /// <summary>
        /// The function multiplies the given row of the current MatrixClass object by a double
        /// </summary>
        public void MultiplyRow(int iRow, double dbl) {
            this.MultiplyRow(iRow, Fraction.ToFraction(dbl));
        }

        /// <summary>
        /// The function adds two rows for current MatrixClass object
        /// It performs the following calculation:
        /// iTargetRow = iTargetRow + iMultiple*iSecondRow
        /// </summary>
        public void AddRow(int iTargetRow, int iSecondRow, Fraction iMultiple) {
            for (int j = 0; j < this.Cols; j++)
                this[iTargetRow, j] += (this[iSecondRow, j] * iMultiple);
        }

        /// <summary>
        /// The function interchanges two rows of the current MatrixClass object
        /// </summary>
        public void InterchangeRow(int iRow1, int iRow2) {
            for (int j = 0; j < this.Cols; j++) {
                Fraction temp = this[iRow1, j];
                this[iRow1, j] = this[iRow2, j];
                this[iRow2, j] = temp;
            }
        }

        /// <summary>
        /// The function concatenates the two given matrices column-wise
        /// it can be helpful in a equation solver class where the augmented MatrixClass is obtained by concatenation
        /// </summary>
        public static MatrixClass Concatenate(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            if (MatrixClass1.Rows != MatrixClass2.Rows)
                throw new MatrixClassException("Concatenation not possible");
            MatrixClass MatrixClass = new MatrixClass(MatrixClass1.Rows, MatrixClass1.Cols + MatrixClass2.Cols);
            for (int i = 0; i < MatrixClass.Rows; i++)
            for (int j = 0; j < MatrixClass.Cols; j++) {
                if (j < MatrixClass1.Cols)
                    MatrixClass[i, j] = MatrixClass1[i, j];
                else
                    MatrixClass[i, j] = MatrixClass2[i, j - MatrixClass1.Cols];
            }

            return MatrixClass;
        }

        /// <summary>
        /// The function returns the determinent of the current MatrixClass object as Fraction
        /// It computes the determinent by reducing the MatrixClass to reduced echelon form using row operations
        /// The function is very fast and efficient but may raise overflow exceptions in some cases.
        /// In such cases use the Determinent() function which computes determinent in the traditional 
        /// manner(by using minors)
        /// </summary>
        public Fraction DeterminentFast() {
            if (this.Rows != this.Cols)
                throw new MatrixClassException("Determinent of a non-square MatrixClass doesn't exist");
            Fraction det = new Fraction(1);
            try {
                MatrixClass ReducedEchelonMatrixClass = this.Duplicate();
                for (int i = 0; i < this.Rows; i++) {
                    if (ReducedEchelonMatrixClass[i, i] == 0) // if diagonal entry is zero, 
                        for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++)
                            if (ReducedEchelonMatrixClass[j, i] != 0) //check if some below entry is non-zero
                            {
                                ReducedEchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                                det *= -1; //interchanging two rows negates the determinent
                            }

                    det *= ReducedEchelonMatrixClass[i, i];
                    ReducedEchelonMatrixClass.MultiplyRow(i, Fraction.Inverse(ReducedEchelonMatrixClass[i, i]));

                    for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++) {
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                    }

                    for (int j = i - 1; j >= 0; j--) {
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                    }
                }

                return det;
            } catch (Exception) {
                throw new MatrixClassException("Determinent of the given MatrixClass could not be calculated");
            }
        }

        /// <summary>
        /// The function returns the determinent of the current MatrixClass object as Fraction
        /// It computes the determinent in the traditional way (i.e. using minors)
        /// It can be much slower(due to recursion) if the given MatrixClass has order greater than 6
        /// Try using DeterminentFast() function if the order of MatrixClass is greater than 6
        /// </summary>
        public Fraction Determinent() {
            return Determinent(this);
        }

        /// <summary>
        /// The helper function for the above Determinent() method
        /// it calls itself recursively and computes determinent using minors
        /// </summary>
        private Fraction Determinent(MatrixClass MatrixClass) {
            Fraction det = new Fraction(0);
            if (MatrixClass.Rows != MatrixClass.Cols)
                throw new MatrixClassException("Determinent of a non-square MatrixClass doesn't exist");
            if (MatrixClass.Rows == 1)
                return MatrixClass[0, 0];
            for (int j = 0; j < MatrixClass.Cols; j++)
                det += (MatrixClass[0, j] * Determinent(MatrixClass.Minor(MatrixClass, 0, j)) * (int) System.Math.Pow(-1, 0 + j));
            return det;
        }


        /// <summary>
        /// The function returns the Echelon form of the current MatrixClass
        /// </summary>
        public MatrixClass EchelonForm() {
            try {
                MatrixClass EchelonMatrixClass = this.Duplicate();
                for (int i = 0; i < this.Rows; i++) {
                    if (EchelonMatrixClass[i, i] == 0) // if diagonal entry is zero, 
                        for (int j = i + 1; j < EchelonMatrixClass.Rows; j++)
                            if (EchelonMatrixClass[j, i] != 0) //check if some below entry is non-zero
                                EchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                    if (EchelonMatrixClass[i, i] == 0) // if not found any non-zero diagonal entry
                        continue; // increment i;
                    if (EchelonMatrixClass[i, i] != 1) // if diagonal entry is not 1 , 	
                        for (int j = i + 1; j < EchelonMatrixClass.Rows; j++)
                            if (EchelonMatrixClass[j, i] == 1) //check if some below entry is 1
                                EchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                    EchelonMatrixClass.MultiplyRow(i, Fraction.Inverse(EchelonMatrixClass[i, i]));
                    for (int j = i + 1; j < EchelonMatrixClass.Rows; j++)
                        EchelonMatrixClass.AddRow(j, i, -EchelonMatrixClass[j, i]);
                }

                return EchelonMatrixClass;
            } catch (Exception) {
                throw new MatrixClassException("MatrixClass can not be reduced to Echelon form");
            }
        }

        /// <summary>
        /// The function returns the reduced echelon form of the current MatrixClass
        /// </summary>
        public MatrixClass ReducedEchelonForm() {
            try {
                MatrixClass ReducedEchelonMatrixClass = this.Duplicate();
                for (int i = 0; i < this.Rows; i++) {
                    if (ReducedEchelonMatrixClass[i, i] == 0) // if diagonal entry is zero, 
                        for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++)
                            if (ReducedEchelonMatrixClass[j, i] != 0) //check if some below entry is non-zero
                                ReducedEchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                    if (ReducedEchelonMatrixClass[i, i] == 0) // if not found any non-zero diagonal entry
                        continue; // increment i;
                    if (ReducedEchelonMatrixClass[i, i] != 1) // if diagonal entry is not 1 , 	
                        for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++)
                            if (ReducedEchelonMatrixClass[j, i] == 1) //check if some below entry is 1
                                ReducedEchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                    ReducedEchelonMatrixClass.MultiplyRow(i, Fraction.Inverse(ReducedEchelonMatrixClass[i, i]));
                    for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++)
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                    for (int j = i - 1; j >= 0; j--)
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                }

                return ReducedEchelonMatrixClass;
            } catch (Exception) {
                throw new MatrixClassException("MatrixClass can not be reduced to Echelon form");
            }
        }

        /// <summary>
        /// The function returns the inverse of the current MatrixClass using Reduced Echelon Form method
        /// The function is very fast and efficient but may raise overflow exceptions in some cases.
        /// In such cases use the Inverse() method which computes inverse in the traditional way(using adjoint).
        /// </summary>
        public MatrixClass InverseFast() {
            if (this.DeterminentFast() == 0)
                throw new MatrixClassException("Inverse of a singular MatrixClass is not possible");
            try {
                MatrixClass IdentityMatrixClass = MatrixClass.IdentityMatrixClass(this.Rows, this.Cols);
                MatrixClass ReducedEchelonMatrixClass = this.Duplicate();
                for (int i = 0; i < this.Rows; i++) {
                    if (ReducedEchelonMatrixClass[i, i] == 0) // if diagonal entry is zero, 
                        for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++)
                            if (ReducedEchelonMatrixClass[j, i] != 0) //check if some below entry is non-zero
                            {
                                ReducedEchelonMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                                IdentityMatrixClass.InterchangeRow(i, j); // then interchange the two rows
                            }

                    IdentityMatrixClass.MultiplyRow(i, Fraction.Inverse(ReducedEchelonMatrixClass[i, i]));
                    ReducedEchelonMatrixClass.MultiplyRow(i, Fraction.Inverse(ReducedEchelonMatrixClass[i, i]));

                    for (int j = i + 1; j < ReducedEchelonMatrixClass.Rows; j++) {
                        IdentityMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                    }

                    for (int j = i - 1; j >= 0; j--) {
                        IdentityMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                        ReducedEchelonMatrixClass.AddRow(j, i, -ReducedEchelonMatrixClass[j, i]);
                    }
                }

                return IdentityMatrixClass;
            } catch (Exception) {
                throw new MatrixClassException("Inverse of the given MatrixClass could not be calculated");
            }
        }

        /// <summary>
        /// The function returns the inverse of the current MatrixClass in the traditional way(by adjoint method)
        /// It can be much slower if the given MatrixClass has order greater than 6
        /// Try using InverseFast() function if the order of MatrixClass is greater than 6
        /// </summary>
        public MatrixClass Inverse() {
            if (this.Determinent() == 0)
                throw new MatrixClassException("Inverse of a singular MatrixClass is not possible");
            int b = FindB((int) this.Determinent().Numerator);
            return this.Adjoint(b);
        }

        private int FindB(int Det) {
            int result = 0;
            for (int i = 2; i < 26; i++) {
                if (((i * Det) % 26) == 1) {
                    result = i;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// The function returns the adjoint of the current MatrixClass
        /// </summary>
        public MatrixClass Adjoint(int b) {
            if (this.Rows != this.Cols)
                throw new MatrixClassException("Adjoint of a non-square MatrixClass does not exists");
            MatrixClass AdjointMatrixClass = new MatrixClass(this.Rows, this.Cols);
            for (int i = 0; i < this.Rows; i++)
            for (int j = 0; j < this.Cols; j++)
                AdjointMatrixClass[i, j] = b * Math.Pow(-1, i + j) * (Minor(this, j, i).Determinent());
            return AdjointMatrixClass;
        }

        /// <summary>
        /// The function returns the transpose of the current MatrixClass
        /// </summary>
        public MatrixClass Transpose() {
            MatrixClass TransposeMatrixClass = new MatrixClass(this.Cols, this.Rows);
            for (int i = 0; i < TransposeMatrixClass.Rows; i++)
            for (int j = 0; j < TransposeMatrixClass.Cols; j++)
                TransposeMatrixClass[i, j] = this[j, i];
            return TransposeMatrixClass;
        }

        /// <summary>
        /// The function duplicates the current MatrixClass object
        /// </summary>
        public MatrixClass Duplicate() {
            MatrixClass MatrixClass = new MatrixClass(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                MatrixClass[i, j] = this[i, j];
            return MatrixClass;
        }

        /// <summary>
        /// The function returns a Scalar MatrixClass of dimension ( Row x Col ) and scalar K
        /// </summary>
        public static MatrixClass ScalarMatrixClass(int iRows, int iCols, int K) {
            Fraction zero = new Fraction(0);
            Fraction scalar = new Fraction(K);
            MatrixClass MatrixClass = new MatrixClass(iRows, iCols);
            for (int i = 0; i < iRows; i++)
            for (int j = 0; j < iCols; j++) {
                if (i == j)
                    MatrixClass[i, j] = scalar;
                else
                    MatrixClass[i, j] = zero;
            }

            return MatrixClass;
        }

        /// <summary>
        /// The function returns an identity MatrixClass of dimensions ( Row x Col )
        /// </summary>
        public static MatrixClass IdentityMatrixClass(int iRows, int iCols) {
            return ScalarMatrixClass(iRows, iCols, 1);
        }

        /// <summary>
        /// The function returns a Unit MatrixClass of dimension ( Row x Col )
        /// </summary>
        public static MatrixClass UnitMatrixClass(int iRows, int iCols) {
            Fraction temp = new Fraction(1);
            MatrixClass MatrixClass = new MatrixClass(iRows, iCols);
            for (int i = 0; i < iRows; i++)
            for (int j = 0; j < iCols; j++)
                MatrixClass[i, j] = temp;
            return MatrixClass;
        }

        /// <summary>
        /// The function returns a Null MatrixClass of dimension ( Row x Col )
        /// </summary>
        public static MatrixClass NullMatrixClass(int iRows, int iCols) {
            Fraction temp = new Fraction(0);
            MatrixClass MatrixClass = new MatrixClass(iRows, iCols);
            for (int i = 0; i < iRows; i++)
            for (int j = 0; j < iCols; j++)
                MatrixClass[i, j] = temp;
            return MatrixClass;
        }

        /// <summary>
        /// Operators for the MatrixClass object
        /// includes -(unary), and binary opertors such as +,-,*,/
        /// </summary>
        public static MatrixClass operator -(MatrixClass MatrixClass) {
            return MatrixClass.Negate(MatrixClass);
        }

        public static MatrixClass operator +(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            return MatrixClass.Add(MatrixClass1, MatrixClass2);
        }

        public static MatrixClass operator -(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            return MatrixClass.Add(MatrixClass1, -MatrixClass2);
        }

        public static MatrixClass operator *(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            return MatrixClass.Multiply(MatrixClass1, MatrixClass2);
        }

        public static MatrixClass operator *(MatrixClass MatrixClass1, int iNo) {
            return MatrixClass.Multiply(MatrixClass1, iNo);
        }

        public static MatrixClass operator *(MatrixClass MatrixClass1, double dbl) {
            return MatrixClass.Multiply(MatrixClass1, Fraction.ToFraction(dbl));
        }

        public static MatrixClass operator *(MatrixClass MatrixClass1, Fraction frac) {
            return MatrixClass.Multiply(MatrixClass1, frac);
        }

        public static MatrixClass operator *(int iNo, MatrixClass MatrixClass1) {
            return MatrixClass.Multiply(MatrixClass1, iNo);
        }

        public static MatrixClass operator *(double dbl, MatrixClass MatrixClass1) {
            return MatrixClass.Multiply(MatrixClass1, Fraction.ToFraction(dbl));
        }

        public static MatrixClass operator *(Fraction frac, MatrixClass MatrixClass1) {
            return MatrixClass.Multiply(MatrixClass1, frac);
        }

        public static MatrixClass operator /(MatrixClass MatrixClass1, int iNo) {
            return MatrixClass.Multiply(MatrixClass1, Fraction.Inverse(new Fraction(iNo)));
        }

        public static MatrixClass operator /(MatrixClass MatrixClass1, double dbl) {
            return MatrixClass.Multiply(MatrixClass1, Fraction.Inverse(Fraction.ToFraction(dbl)));
        }

        public static MatrixClass operator /(MatrixClass MatrixClass1, Fraction frac) {
            return MatrixClass.Multiply(MatrixClass1, Fraction.Inverse(frac));
        }


        /// <summary>
        /// Internal Fucntions for the above operators
        /// </summary>
        private static MatrixClass Negate(MatrixClass MatrixClass) {
            return MatrixClass.Multiply(MatrixClass, -1);
        }

        private static MatrixClass Add(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            if (MatrixClass1.Rows != MatrixClass2.Rows || MatrixClass1.Cols != MatrixClass2.Cols)
                throw new MatrixClassException("Operation not possible");
            MatrixClass result = new MatrixClass(MatrixClass1.Rows, MatrixClass1.Cols);
            for (int i = 0; i < result.Rows; i++)
            for (int j = 0; j < result.Cols; j++)
                result[i, j] = MatrixClass1[i, j] + MatrixClass2[i, j];
            return result;
        }

        private static MatrixClass Multiply(MatrixClass MatrixClass1, MatrixClass MatrixClass2) {
            if (MatrixClass1.Cols != MatrixClass2.Rows)
                throw new MatrixClassException("Operation not possible");
            MatrixClass result = MatrixClass.NullMatrixClass(MatrixClass1.Rows, MatrixClass2.Cols);
            for (int i = 0; i < result.Rows; i++)
            for (int j = 0; j < result.Cols; j++)
            for (int k = 0; k < MatrixClass1.Cols; k++)
                result[i, j] += MatrixClass1[i, k] * MatrixClass2[k, j];
            return result;
        }

        private static MatrixClass Multiply(MatrixClass MatrixClass, int iNo) {
            MatrixClass result = new MatrixClass(MatrixClass.Rows, MatrixClass.Cols);
            for (int i = 0; i < MatrixClass.Rows; i++)
            for (int j = 0; j < MatrixClass.Cols; j++)
                result[i, j] = MatrixClass[i, j] * iNo;
            return result;
        }

        private static MatrixClass Multiply(MatrixClass MatrixClass, Fraction frac) {
            MatrixClass result = new MatrixClass(MatrixClass.Rows, MatrixClass.Cols);
            for (int i = 0; i < MatrixClass.Rows; i++)
            for (int j = 0; j < MatrixClass.Cols; j++)
                result[i, j] = MatrixClass[i, j] * frac;
            return result;
        }
    } //end class MatrixClass

    /// <summary>
    /// Exception class for MatrixClass class, derived from System.Exception
    /// </summary>
    public class MatrixClassException : Exception {
        public MatrixClassException()
            : base() { }

        public MatrixClassException(string Message)
            : base(Message) { }

        public MatrixClassException(string Message, Exception InnerException)
            : base(Message, InnerException) { }
    } // end class MatrixClassException


    /// <summary>
    /// Class name: Fraction
    /// Developed by: Syed Mehroz Alam
    /// Email: smehrozalam@yahoo.com
    /// URL: Programming Home "http://www.geocities.com/smehrozalam/"
    /// Version: 2.0
    /// 
    /// What's new in version 2.0:
    /// 	*	Changed Numerator and Denominator from Int32(integer) to Int64(long) for increased range
    /// 	*	renamed ConvertToString() to (overloaded) ToString()
    /// 	*	added the capability of detecting/raising overflow exceptions
    /// 	*	Fixed the bug that very small numbers e.g. 0.00000001 could not be converted to fraction
    /// 	*	Other minor bugs fixed
    /// 
    /// Properties:
    /// 	Numerator: Set/Get value for Numerator
    /// 	Denominator:  Set/Get value for Numerator
    /// 	Value:  Set an integer value for the fraction
    /// 
    /// Constructors:
    /// 	no arguments:	initializes fraction as 0/1
    /// 	(Numerator, Denominator): initializes fraction with the given numerator and denominator values
    /// 	(integer):	initializes fraction with the given integer value
    /// 	(long):	initializes fraction with the given long value
    /// 	(double):	initializes fraction with the given double value
    /// 	(string):	initializes fraction with the given string value
    /// 				the string can be an in the form of and integer, double or fraction.
    /// 				e.g it can be like "123" or "123.321" or "123/456"
    /// 
    /// Public Methods (Description is given with respective methods' definitions)
    /// 	(override) string ToString(Fraction)
    /// 	Fraction ToFraction(string)
    /// 	Fraction ToFraction(double)
    /// 	double ToDouble(Fraction)
    /// 	Fraction Duplicate()
    /// 	Fraction Inverse(integer)
    /// 	Fraction Inverse(Fraction)
    /// 	ReduceFraction(Fraction)
    /// 	Equals(object)
    /// 	GetHashCode()
    /// 
    ///	Private Methods (Description is given with respective methods' definitions)
    /// 	Initialize(Numerator, Denominator)
    /// 	Fraction Negate(Fraction)
    /// 	Fraction Add(Fraction1, Fraction2)
    /// 
    /// Overloaded Operators (overloaded for Fractions, Integers and Doubles)
    /// 	Unary: -
    /// 	Binary: +,-,*,/ 
    /// 	Relational and Logical Operators: ==,!=,<,>,<=,>=
    /// 
    /// Overloaded user-defined conversions
    /// 	Implicit:	From double/long/string to Fraction
    /// 	Explicit:	From Fraction to double/string
    /// </summary>
    public class Fraction {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        long m_iNumerator;

        long m_iDenominator;

        /// <summary>
        /// Constructors
        /// </summary>
        public Fraction() {
            Initialize(0, 1);
        }

        public Fraction(long iWholeNumber) {
            Initialize(iWholeNumber, 1);
        }

        public Fraction(double dDecimalValue) {
            Fraction temp = ToFraction(dDecimalValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        public Fraction(string strValue) {
            Fraction temp = ToFraction(strValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        public Fraction(long iNumerator, long iDenominator) {
            Initialize(iNumerator, iDenominator);
        }

        /// <summary>
        /// Internal function for constructors
        /// </summary>
        private void Initialize(long iNumerator, long iDenominator) {
            Numerator = iNumerator;
            Denominator = iDenominator;
            ReduceFraction(this);
        }

        /// <summary>
        /// Properites
        /// </summary>
        public long Denominator {
            get { return m_iDenominator; }
            set {
                if (value != 0)
                    m_iDenominator = value;
                else
                    throw new FractionException("Denominator cannot be assigned a ZERO Value");
            }
        }

        public long Numerator {
            get { return m_iNumerator; }
            set {
                m_iNumerator = value % 26;
                if (m_iNumerator < 0)
                    m_iNumerator += 26;
            }
        }

        public long Value {
            set {
                m_iNumerator = value;
                m_iDenominator = 1;
            }
        }


        /// <summary>
        /// The function takes a Fraction object and returns its value as double
        /// </summary>
        public static double ToDouble(Fraction frac) {
            return ((double) frac.Numerator / frac.Denominator);
        }

        /// <summary>
        /// The function returns the current Fraction object as double
        /// </summary>
        public double ToDouble() {
            return ((double) this.Numerator / this.Denominator);
        }

        /// <summary>
        /// The function returns the current Fraction object as a string
        /// </summary>
        public override string ToString() {
            string str;
            if (this.Denominator == 1)
                str = this.Numerator.ToString();
            else
                str = this.Numerator + "/" + this.Denominator;
            return str;
        }

        /// <summary>
        /// The function takes an string as an argument and returns its corresponding reduced fraction
        /// the string can be an in the form of and integer, double or fraction.
        /// e.g it can be like "123" or "123.321" or "123/456"
        /// </summary>
        public static Fraction ToFraction(string strValue) {
            int i;
            for (i = 0; i < strValue.Length; i++)
                if (strValue[i] == '/')
                    break;

            if (i == strValue.Length) // if string is not in the form of a fraction
                // then it is double or integer
                return (ToFraction(Convert.ToDouble(strValue)));

            // else string is in the form of Numerator/Denominator
            long iNumerator = Convert.ToInt64(strValue.Substring(0, i));
            long iDenominator = Convert.ToInt64(strValue.Substring(i + 1));
            return new Fraction(iNumerator, iDenominator);
        }


        /// <summary>
        /// The function takes a floating point number as an argument 
        /// and returns its corresponding reduced fraction
        /// </summary>
        public static Fraction ToFraction(double dValue) {
            try {
                checked {
                    Fraction frac;
                    if (dValue % 1 == 0) // if whole number
                    {
                        frac = new Fraction((long) dValue);
                    } else {
                        double dTemp = dValue;
                        long iMultiple = 1;
                        string strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0) // if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }

                        int i = 0;
                        while (strTemp[i] != '.')
                            i++;
                        int iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0) {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }

                        frac = new Fraction((int) Math.Round(dTemp), iMultiple);
                    }

                    return frac;
                }
            } catch (OverflowException) {
                throw new FractionException("Conversion not possible due to overflow");
            } catch (Exception) {
                throw new FractionException("Conversion not possible");
            }
        }

        /// <summary>
        /// The function replicates current Fraction object
        /// </summary>
        public Fraction Duplicate() {
            Fraction frac = new Fraction();
            frac.Numerator = Numerator;
            frac.Denominator = Denominator;
            return frac;
        }

        /// <summary>
        /// The function returns the inverse of a Fraction object
        /// </summary>
        public static Fraction Inverse(Fraction frac1) {
            if (frac1.Numerator == 0)
                throw new FractionException("Operation not possible (Denominator cannot be assigned a ZERO Value)");

            long iNumerator = frac1.Denominator;
            long iDenominator = frac1.Numerator;
            return (new Fraction(iNumerator, iDenominator));
        }


        /// <summary>
        /// Operators for the Fraction object
        /// includes -(unary), and binary opertors such as +,-,*,/
        /// also includes relational and logical operators such as ==,!=,<,>,<=,>=
        /// </summary>
        public static Fraction operator -(Fraction frac1) {
            return (Negate(frac1));
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2) {
            return (Add(frac1, frac2));
        }

        public static Fraction operator +(int iNo, Fraction frac1) {
            return (Add(frac1, new Fraction(iNo)));
        }

        public static Fraction operator +(Fraction frac1, int iNo) {
            return (Add(frac1, new Fraction(iNo)));
        }

        public static Fraction operator +(double dbl, Fraction frac1) {
            return (Add(frac1, Fraction.ToFraction(dbl)));
        }

        public static Fraction operator +(Fraction frac1, double dbl) {
            return (Add(frac1, Fraction.ToFraction(dbl)));
        }

        public static Fraction operator -(Fraction frac1, Fraction frac2) {
            return (Add(frac1, -frac2));
        }

        public static Fraction operator -(int iNo, Fraction frac1) {
            return (Add(-frac1, new Fraction(iNo)));
        }

        public static Fraction operator -(Fraction frac1, int iNo) {
            return (Add(frac1, -(new Fraction(iNo))));
        }

        public static Fraction operator -(double dbl, Fraction frac1) {
            return (Add(-frac1, Fraction.ToFraction(dbl)));
        }

        public static Fraction operator -(Fraction frac1, double dbl) {
            return (Add(frac1, -Fraction.ToFraction(dbl)));
        }

        public static Fraction operator *(Fraction frac1, Fraction frac2) {
            return (Multiply(frac1, frac2));
        }

        public static Fraction operator *(int iNo, Fraction frac1) {
            return (Multiply(frac1, new Fraction(iNo)));
        }

        public static Fraction operator *(Fraction frac1, int iNo) {
            return (Multiply(frac1, new Fraction(iNo)));
        }

        public static Fraction operator *(double dbl, Fraction frac1) {
            return (Multiply(frac1, Fraction.ToFraction(dbl)));
        }

        public static Fraction operator *(Fraction frac1, double dbl) {
            return (Multiply(frac1, Fraction.ToFraction(dbl)));
        }

        public static Fraction operator /(Fraction frac1, Fraction frac2) {
            return (Multiply(frac1, Inverse(frac2)));
        }

        public static Fraction operator /(int iNo, Fraction frac1) {
            return (Multiply(Inverse(frac1), new Fraction(iNo)));
        }

        public static Fraction operator /(Fraction frac1, int iNo) {
            return (Multiply(frac1, Inverse(new Fraction(iNo))));
        }

        public static Fraction operator /(double dbl, Fraction frac1) {
            return (Multiply(Inverse(frac1), Fraction.ToFraction(dbl)));
        }

        public static Fraction operator /(Fraction frac1, double dbl) {
            return (Multiply(frac1, Fraction.Inverse(Fraction.ToFraction(dbl))));
        }

        public static bool operator ==(Fraction frac1, Fraction frac2) {
            return frac1.Equals(frac2);
        }

        public static bool operator !=(Fraction frac1, Fraction frac2) {
            return (!frac1.Equals(frac2));
        }

        public static bool operator ==(Fraction frac1, int iNo) {
            return frac1.Equals(new Fraction(iNo));
        }

        public static bool operator !=(Fraction frac1, int iNo) {
            return (!frac1.Equals(new Fraction(iNo)));
        }

        public static bool operator ==(Fraction frac1, double dbl) {
            return frac1.Equals(new Fraction(dbl));
        }

        public static bool operator !=(Fraction frac1, double dbl) {
            return (!frac1.Equals(new Fraction(dbl)));
        }

        public static bool operator <(Fraction frac1, Fraction frac2) {
            return frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator;
        }

        public static bool operator >(Fraction frac1, Fraction frac2) {
            return frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator;
        }

        public static bool operator <=(Fraction frac1, Fraction frac2) {
            return frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator;
        }

        public static bool operator >=(Fraction frac1, Fraction frac2) {
            return frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator;
        }

        /// <summary>
        /// checks whether two fractions are equal
        /// </summary>
        public override bool Equals(object obj) {
            Fraction frac = (Fraction) obj;
            return (Numerator == frac.Numerator && Denominator == frac.Denominator);
        }

        /// <summary>
        /// returns a hash code for this fraction
        /// </summary>
        public override int GetHashCode() {
            return (Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF));
        }

        /// <summary>
        /// internal function for negation
        /// </summary>
        private static Fraction Negate(Fraction frac1) {
            long iNumerator = -frac1.Numerator;
            long iDenominator = frac1.Denominator;
            return (new Fraction(iNumerator, iDenominator));
        }

        /// <summary>
        /// internal functions for binary operations
        /// </summary>
        private static Fraction Add(Fraction frac1, Fraction frac2) {
            try {
                checked {
                    long iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            } catch (OverflowException) {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            } catch (Exception) {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        private static Fraction Multiply(Fraction frac1, Fraction frac2) {
            try {
                checked {
                    long iNumerator = frac1.Numerator * frac2.Numerator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            } catch (OverflowException) {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            } catch (Exception) {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        /// <summary>
        /// The function returns GCD of two numbers (used for reducing a Fraction)
        /// </summary>
        private static long GCD(long iNo1, long iNo2) {
            // take absolute values
            if (iNo1 < 0) iNo1 = -iNo1;
            if (iNo2 < 0) iNo2 = -iNo2;

            do {
                if (iNo1 < iNo2) {
                    long tmp = iNo1; // swap the two operands
                    iNo1 = iNo2;
                    iNo2 = tmp;
                }

                iNo1 = iNo1 % iNo2;
            } while (iNo1 != 0);

            return iNo2;
        }

        /// <summary>
        /// The function reduces(simplifies) a Fraction object by dividing both its numerator 
        /// and denominator by their GCD
        /// </summary>
        public static void ReduceFraction(Fraction frac) {
            try {
                if (frac.Numerator == 0) {
                    frac.Denominator = 1;
                    return;
                }

                long iGCD = GCD(frac.Numerator, frac.Denominator);
                frac.Numerator /= iGCD;
                frac.Denominator /= iGCD;

                if (frac.Denominator < 0) // if -ve sign in denominator
                {
                    //pass -ve sign to numerator
                    frac.Numerator *= -1;
                    frac.Denominator *= -1;
                }
            } // end try
            catch (Exception exp) {
                throw new FractionException("Cannot reduce Fraction: " + exp.Message);
            }
        }
    } //end class Fraction

    /// <summary>
    /// Exception class for Fraction, derived from System.Exception
    /// </summary>
    public class FractionException : Exception {
        public FractionException()
            : base() { }

        public FractionException(string Message)
            : base(Message) { }

        public FractionException(string Message, Exception InnerException)
            : base(Message, InnerException) { }
    }
}