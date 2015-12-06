using Android.OS;
using Android.Runtime;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.ViewModels;
using MvvmCross.Droid.Support.V17.Leanback.Fragments.EventSource;
using System;

namespace MvvmCross.Droid.Support.V17.Leanback.Fragments
{
    public class MvxGuidedStepFragment
        : MvxEventSourceGuidedStepFragment
            , IMvxFragmentView
    {
        /// <summary>
        /// Create new instance of a MvxGuidedStepFragment
        /// </summary>
        /// <param name="bundle">Usually this would be MvxViewModelRequest serialized</param>
        /// <returns>Returns an instance of a MvxFragment</returns>
        public static MvxGuidedStepFragment NewInstance(Bundle bundle)
        {
            // Setting Arguments needs to happen before Fragment is attached
            // to Activity. Arguments are persisted when Fragment is recreated!
            var fragment = new MvxGuidedStepFragment { Arguments = bundle };

            return fragment;
        }

        protected MvxGuidedStepFragment()
        {
            this.AddEventListeners();
        }

        protected MvxGuidedStepFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            this.AddEventListeners();
        }

        public IMvxBindingContext BindingContext { get; set; }

        private object _dataContext;

        public object DataContext
        {
            get { return _dataContext; }
            set
            {
                _dataContext = value;
                if (BindingContext != null)
                    BindingContext.DataContext = value;
            }
        }

        public virtual IMvxViewModel ViewModel
        {
            get { return DataContext as IMvxViewModel; }
            set
            {
                DataContext = value;
                OnViewModelSet();
            }
        }

        public virtual void OnViewModelSet()
        {
        }

        public string UniqueImmutableCacheTag => Tag;
    }

    public abstract class MvxGuidedStepFragment<TViewModel>
: MvxGuidedStepFragment
, IMvxFragmentView<TViewModel> where TViewModel : class, IMvxViewModel
    {
        protected MvxGuidedStepFragment()
        {
        }

        protected MvxGuidedStepFragment(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}