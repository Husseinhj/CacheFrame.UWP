using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace CacheFrame.UWP
{
    /// <summary>
    /// This frame library was inheritance by Frame and show your pages, new for first time and you can see your page again from cache in RAM.
    /// iOS tabbar cache your page, so if want to keep your page and render page for first time you can use this.
    /// </summary>
    public class CacheFrame : Frame
    {

        #region Properties

        private Frame frame { get; set; }

        private bool _isCacheEnable;

        /// <summary>
        /// Enable / Disable cache state.
        /// </summary>
        public bool IsCacheEnable
        {
            get => _isCacheEnable;
            set => _isCacheEnable = value;
        }

        #endregion

        /// <summary>
        /// Constractor to create instance of class.
        /// </summary>
        public CacheFrame()
        {
            IsCacheEnable = true;
            frame = this;
        }

        /// <summary>
        /// Constractor to create instance of class.
        /// </summary>
        /// <param name="isCacheEnable">Cache state</param>
        public CacheFrame(bool isCacheEnable)
        {
            IsCacheEnable = isCacheEnable;
            frame = this;
        }

        #region Public methods

        public new bool Navigate(Type sourcePageType)
        {
            return Navigate(sourcePageType, null, null);
        }

        public new bool Navigate(Type sourcePageType, object parameter)
        {
            return Navigate(sourcePageType, parameter, null);
        }

        public new bool Navigate(Type sourcePageType, object parameter, NavigationTransitionInfo infoOverride)
        {
            try
            {
                if (sourcePageType == null)
                    throw new ArgumentNullException(nameof(sourcePageType), "Argument can not be null.");

                var pageObject = Activator.CreateInstance(sourcePageType);

                if (!(pageObject is Page))
                {
                    Debug.WriteLine("Can not cast page to type....");

                    return false;
                }

                return NavigateTo((Page)pageObject, parameter, infoOverride);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(" Exception was happen in Navigate : " + exception);
                return false;
            }
        }

        /// <summary>
        /// Navigate to page if was in back stack so show new one
        /// </summary>
        /// <param name="page">Page class</param>
        /// <param name="parameter">Parmeters</param>
        /// <param name="infoOverride">Navigation transition for show page.</param>
        /// <returns>State of navigation.</returns>
        public bool NavigateTo(Page page, object parameter, NavigationTransitionInfo infoOverride)
        {
            try
            {
                if (page == null)
                    throw new ArgumentNullException(nameof(page), "Argument can not be null");

                var count = CountOfBackStack();
                var pageType = page.GetType();
                List<PageStackEntry> lastPages;
                var wasFounded = false;

                if (!IsCacheEnable)
                {
                    frame.Navigate(pageType, parameter, infoOverride);
                    return true;
                }

                page.NavigationCacheMode = NavigationCacheMode.Enabled;

                Debug.WriteLine("Back stack count [{0}] ", count);

                wasFounded = frame.BackStack.Any(entry => entry.SourcePageType == pageType);
                lastPages = frame.BackStack.ToList();

                if (wasFounded)
                {
                    #region Remove all page except myPage
                    
                    foreach (var pageStackEntry in lastPages)
                    {
                        if (pageStackEntry.SourcePageType != pageType)
                        {
                            frame.BackStack.Remove(pageStackEntry);
                            Debug.WriteLine("Page '{0}' was remove temporary from lastPages.", pageStackEntry.SourcePageType);
                        }
                    }

                    #endregion

                    if (frame.CanGoBack)
                    {
                        frame.GoBack(infoOverride);
                        frame.BackStack.Clear();
                        Debug.WriteLine("Go back work fine :-) ....");
                    }
                    else
                    {
                        Debug.WriteLine("Go back did not work fine :-( ....");
                        return false;
                    }

                    #region Add pages to stack without duplicates

                    lastPages = lastPages.ToLookup(entry => entry.SourcePageType).Select(g => g.First()).ToList();

                    foreach (var pageStackEntry in lastPages)
                    {
                        frame.BackStack.Add(pageStackEntry);
                        Debug.WriteLine("Page '{0}' was added to back stack.", pageStackEntry.SourcePageType);
                    }

                    #endregion
                }
                else
                {
                    Debug.WriteLine("Sorry can not find '" + pageType + "' on back stack, So new navigation ...");
                    frame.BackStack.Add(new PageStackEntry(pageType, parameter, infoOverride));
                    frame.Navigate(pageType, parameter, infoOverride);
                }

                Debug.WriteLine("Back stack count [{0}] ", count);

                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(" Exception was happen in NavigateTo : " + exception);
                return false;
            }
        }

        /// <summary>
        /// Get count of back stack.
        /// </summary>
        /// <returns>Count of back stack.</returns>
        private int CountOfBackStack()
        {
            return frame.BackStackDepth;
        }

        #endregion
    }
}
