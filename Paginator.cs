using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldFlagQuiz
{
	class Paginator
	{
		public const int TotalQuestions = 10;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentPage"></param>
		/// <param name="round"></param>
		/// <returns></returns>
		public List<Question> GeneratePage(int currentPage, List<Question> round)
		{
			List<Question> pageData = new List<Question>();

			if (currentPage >= 0 && currentPage < TotalQuestions)
			{
					pageData.Add(round[currentPage]);
			}
			
			return pageData;
		}
	}
}

//**************************************** OLD CONSTANTS **************************************************************

//// Constants
//public const int TOTAL_QUESTIONS = 10;
//public const int QUESTIONS_PER_PAGE = 1;
//public const int QUESTIONS_REMAINING = TOTAL_QUESTIONS % QUESTIONS_PER_PAGE;
//public const int LAST_PAGE = TOTAL_QUESTIONS / QUESTIONS_PER_PAGE;


//*************************************** OLD PAGINATOR FOR FUTURE USE **********************************************************
//public List<Question> GeneratePage(int currentPage)// old
//{
//int startQuestion = currentPage * QUESTIONS_PER_PAGE; //<-old paginator had + 1 here
//const int numOfData = QUESTIONS_PER_PAGE;

//List<Question> pageData = new List<Question>();

//if (currentPage == LAST_PAGE && QUESTIONS_REMAINING > 0)
//{
//	for (int i = startQuestion; i < startQuestion + QUESTIONS_REMAINING; i++)
//	{
//		//pageData.Add(pageData[i]);//old
//		pageData.Add(round[i]);
//	}
//}
//else
//{
//	for (int i = startQuestion; i < startQuestion + numOfData; i++)
//	{
//		//pageData.Add(pageData[i]);//old
//		pageData.Add(round[i]);
//	}
//}

//return pageData;
//}