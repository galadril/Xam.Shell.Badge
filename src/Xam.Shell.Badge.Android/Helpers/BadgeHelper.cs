using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using System;
using System.Linq;
using Xam.Shell.Badge.Droid.Extensions;
using Xamarin.Forms.Platform.Android;
using LP = Android.Views.ViewGroup.LayoutParams;
using XColor = Xamarin.Forms.Color;

namespace Xam.Shell.Badge.Droid.Helpers
{
    /// <summary>
    /// Defines the <see cref="BadgeHelper" />.
    /// </summary>
    internal static class BadgeHelper
    {
        #region Public

        /// <summary>
        /// The ApplyBadge.
        /// </summary>
        /// <param name="bottomNavigationView">The bottomNavigationView<see cref="BottomNavigationItemView"/>.</param>
        /// <param name="color">The color<see cref="XColor"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <param name="textColor">The textColor<see cref="XColor"/>.</param>
        public static void ApplyBadge(this BottomNavigationItemView bottomNavigationView, XColor color, string text,
            XColor textColor)
        {
            if (!bottomNavigationView.GetChildrenOfType<BadgeFrameLayout>().Any())
            {
                bottomNavigationView.SetClipChildren(false);
                bottomNavigationView.SetClipToPadding(false);

                ImageView imageView = bottomNavigationView.GetChildrenOfType<ImageView>().Single();
                bottomNavigationView.RemoveView(imageView);

                FrameLayout badgeContainerFrameLayout = new FrameLayout(bottomNavigationView.Context)
                {
                    LayoutParameters = new FrameLayout.LayoutParams(LP.WrapContent, LP.WrapContent)
                    {
                        Gravity = GravityFlags.CenterHorizontal
                    }
                };

                badgeContainerFrameLayout.AddView(imageView);

                BadgeFrameLayout badgeContainer = CreateBadgeContainer(bottomNavigationView.Context);
                badgeContainer.TopMargin = 20;

                badgeContainer.Visibility = !string.IsNullOrEmpty(text) ? ViewStates.Visible : ViewStates.Invisible;

                badgeContainer.Background = CreateBadgeBackground(bottomNavigationView.Context, color);
                badgeContainer.AddView(CreateBadgeText(bottomNavigationView.Context, text, textColor));

                badgeContainerFrameLayout.AddView(badgeContainer);

                bottomNavigationView.AddView(badgeContainerFrameLayout);

            }
            else
            {
                BadgeFrameLayout badgeContainer = bottomNavigationView.GetChildrenOfType<BadgeFrameLayout>().Single();
                badgeContainer.TopMargin = 20;
                badgeContainer.Visibility = !string.IsNullOrEmpty(text) ? ViewStates.Visible : ViewStates.Invisible;

                ((PaintDrawable)badgeContainer.Background).Paint.Color = color.IsDefault ? XColor.FromRgb(255, 59, 48).ToAndroid() : color.ToAndroid();

                TextView textView = (TextView)badgeContainer.GetChildAt(0);
                textView.Text = text;
                textView.SetTextColor(textColor.IsDefault ? XColor.White.ToAndroid() : textColor.ToAndroid());
                textView.SetTextSize(ComplexUnitType.Sp, 10);
            }
        }

        /// <summary>
        /// The ApplyTinyBadge.
        /// </summary>
        /// <param name="bottomNavigationView">The bottomNavigationView<see cref="BottomNavigationItemView"/>.</param>
        /// <param name="textColor">The textColor<see cref="XColor"/>.</param>
        public static void ApplyTinyBadge(this BottomNavigationItemView bottomNavigationView, XColor textColor)
        {
            if (!bottomNavigationView.GetChildrenOfType<BadgeFrameLayout>().Any())
            {
                bottomNavigationView.SetClipChildren(false);
                bottomNavigationView.SetClipToPadding(false);

                ImageView imageView = bottomNavigationView.GetChildrenOfType<ImageView>().Single();
                bottomNavigationView.RemoveView(imageView);

                FrameLayout badgeContainerFrameLayout = new FrameLayout(bottomNavigationView.Context)
                {
                    LayoutParameters = new FrameLayout.LayoutParams(LP.WrapContent, LP.WrapContent)
                    {
                        Gravity = GravityFlags.CenterHorizontal
                    }
                };

                badgeContainerFrameLayout.AddView(imageView);

                BadgeFrameLayout badgeContainer = CreateBadgeContainer(bottomNavigationView.Context);
                badgeContainer.TopMargin = 24;
                badgeContainer.Visibility = ViewStates.Visible;
                badgeContainer.Background = CreateBadgeBackground(bottomNavigationView.Context, XColor.Transparent);
                badgeContainer.AddView(CreateBadgeText(bottomNavigationView.Context, "●", textColor, 20));

                badgeContainerFrameLayout.AddView(badgeContainer);

                bottomNavigationView.AddView(badgeContainerFrameLayout);
            }
            else
            {
                BadgeFrameLayout badgeContainer = bottomNavigationView.GetChildrenOfType<BadgeFrameLayout>().Single();
                badgeContainer.TopMargin = 24;
                badgeContainer.Visibility = ViewStates.Visible;
                ((PaintDrawable)badgeContainer.Background).Paint.Color = XColor.Transparent.ToAndroid();

                TextView textView = (TextView)badgeContainer.GetChildAt(0);
                textView.Text = "●";
                textView.SetTextSize(ComplexUnitType.Sp, 20);
                textView.SetTextColor(textColor.ToAndroid());
            }
        }

        /// <summary>
        /// The ApplyBadge.
        /// </summary>
        /// <param name="tabView">The tabView<see cref="TabLayout.TabView"/>.</param>
        /// <param name="color">The color<see cref="XColor"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <param name="textColor">The textColor<see cref="XColor"/>.</param>
        public static void ApplyBadge(this TabLayout.TabView tabView, XColor color, string text,
            XColor textColor)
        {
            if (!tabView.GetChildrenOfType<BadgeFrameLayout>().Any())
            {
                tabView.SetClipChildren(false);
                tabView.SetClipToPadding(false);

                TextView tabTextView = tabView.GetChildrenOfType<TextView>().Single();
                tabView.RemoveView(tabTextView);

                FrameLayout badgeContainerFrameLayout = new FrameLayout(tabView.Context)
                {
                    LayoutParameters = new FrameLayout.LayoutParams(LP.WrapContent, LP.WrapContent)
                };

                badgeContainerFrameLayout.AddView(tabTextView);

                BadgeFrameLayout badgeContainer = CreateBadgeContainer(tabView.Context);
                badgeContainer.Visibility = !string.IsNullOrEmpty(text) ? ViewStates.Visible : ViewStates.Invisible;

                badgeContainer.Background = CreateBadgeBackground(tabView.Context, color);
                badgeContainer.AddView(CreateBadgeText(tabView.Context, text, textColor));

                badgeContainerFrameLayout.AddView(badgeContainer);

                tabView.AddView(badgeContainerFrameLayout);
            }
            else
            {
                BadgeFrameLayout badgeContainer = tabView.GetChildrenOfType<BadgeFrameLayout>().Single();
                badgeContainer.Visibility = !string.IsNullOrEmpty(text) ? ViewStates.Visible : ViewStates.Invisible;

                ((PaintDrawable)badgeContainer.Background).Paint.Color = color.IsDefault ? XColor.FromRgb(255, 59, 48).ToAndroid() : color.ToAndroid();

                TextView textView = (TextView)badgeContainer.GetChildAt(0);
                textView.Text = text;
                textView.SetTextColor(textColor.IsDefault ? XColor.White.ToAndroid() : textColor.ToAndroid());
            }
        }

        #endregion

        /// <summary>
        /// The CreateBadgeContainer.
        /// </summary>
        /// <param name="context">The context<see cref="Context"/>.</param>
        /// <returns>The <see cref="BadgeFrameLayout"/>.</returns>
        static BadgeFrameLayout CreateBadgeContainer(Context context)
        {
            BadgeFrameLayout badgeFrameLayout = new BadgeFrameLayout(context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(LP.WrapContent, LP.WrapContent)
                {
                    Gravity = GravityFlags.Top | GravityFlags.Right
                }
            };

            badgeFrameLayout.SetPadding(
                (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 6, context.Resources.DisplayMetrics),
                (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 2, context.Resources.DisplayMetrics),
                (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 6, context.Resources.DisplayMetrics),
                (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 2, context.Resources.DisplayMetrics));

            return badgeFrameLayout;
        }

        /// <summary>
        /// The CreateBadgeText.
        /// </summary>
        /// <param name="context">The context<see cref="Context"/>.</param>
        /// <param name="text">The text<see cref="string"/>.</param>
        /// <param name="textColor">The textColor<see cref="XColor"/>.</param>
        /// <param name="textSize">The textSize<see cref="int"/>.</param>
        /// <returns>The <see cref="TextView"/>.</returns>
        static TextView CreateBadgeText(Context context, string text, XColor textColor, int textSize = 10)
        {
            var textView = new TextView(context)
            {
                Text = text,
                LayoutParameters = new FrameLayout.LayoutParams(LP.WrapContent, LP.WrapContent)
                {
                    Gravity = GravityFlags.Center
                }
            };

            textView.SetTextColor(textColor.IsDefault ? XColor.White.ToAndroid() : textColor.ToAndroid());
            textView.SetTextSize(ComplexUnitType.Sp, textSize);

            return textView;
        }

        /// <summary>
        /// The CreateBadgeBackground.
        /// </summary>
        /// <param name="context">The context<see cref="Context"/>.</param>
        /// <param name="color">The color<see cref="XColor"/>.</param>
        /// <returns>The <see cref="PaintDrawable"/>.</returns>
        static PaintDrawable CreateBadgeBackground(Context context, XColor color)
        {
            var badgeFrameLayoutBackground = new PaintDrawable();

            badgeFrameLayoutBackground.Paint.Color =
                color.IsDefault ? XColor.FromRgb(255, 59, 48).ToAndroid() : color.ToAndroid();

            badgeFrameLayoutBackground.Shape = new RectShape();
            badgeFrameLayoutBackground.SetCornerRadius(TypedValue.ApplyDimension(ComplexUnitType.Dip, 8,
                context.Resources.DisplayMetrics));

            return badgeFrameLayoutBackground;
        }

        /// <summary>
        /// Defines the <see cref="BadgeFrameLayout" />.
        /// </summary>
        internal class BadgeFrameLayout : FrameLayout
        {
            #region Constructor & Destructor

            /// <summary>
            /// Initializes a new instance of the <see cref="BadgeFrameLayout"/> class.
            /// </summary>
            /// <param name="javaReference">The javaReference<see cref="IntPtr"/>.</param>
            /// <param name="transfer">The transfer<see cref="JniHandleOwnership"/>.</param>
            protected BadgeFrameLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BadgeFrameLayout"/> class.
            /// </summary>
            /// <param name="context">The context<see cref="Context"/>.</param>
            public BadgeFrameLayout(Context context) : base(context)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BadgeFrameLayout"/> class.
            /// </summary>
            /// <param name="context">The context<see cref="Context"/>.</param>
            /// <param name="attrs">The attrs<see cref="IAttributeSet"/>.</param>
            public BadgeFrameLayout(Context context, IAttributeSet attrs) : base(context, attrs)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BadgeFrameLayout"/> class.
            /// </summary>
            /// <param name="context">The context<see cref="Context"/>.</param>
            /// <param name="attrs">The attrs<see cref="IAttributeSet"/>.</param>
            /// <param name="defStyleAttr">The defStyleAttr<see cref="int"/>.</param>
            public BadgeFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BadgeFrameLayout"/> class.
            /// </summary>
            /// <param name="context">The context<see cref="Context"/>.</param>
            /// <param name="attrs">The attrs<see cref="IAttributeSet"/>.</param>
            /// <param name="defStyleAttr">The defStyleAttr<see cref="int"/>.</param>
            /// <param name="defStyleRes">The defStyleRes<see cref="int"/>.</param>
            public BadgeFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
            {
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets or sets the TopMargin.
            /// </summary>
            public int TopMargin { get; set; } = 10;

            /// <summary>
            /// Gets or sets the RightMargin.
            /// </summary>
            public int RightMargin { get; set; } = 10;

            #endregion

            #region Protected

            /// <summary>
            /// The OnMeasure.
            /// </summary>
            /// <param name="widthMeasureSpec">The widthMeasureSpec<see cref="int"/>.</param>
            /// <param name="heightMeasureSpec">The heightMeasureSpec<see cref="int"/>.</param>
            protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
            {
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

                if (LayoutParameters is MarginLayoutParams layoutParameters)
                {
                    int rightMargin = -(MeasuredWidth - (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, RightMargin, Context.Resources.DisplayMetrics));
                    int topMargin = -(MeasuredHeight - (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, TopMargin, Context.Resources.DisplayMetrics));

                    layoutParameters.SetMargins(layoutParameters.LeftMargin, topMargin, rightMargin, layoutParameters.BottomMargin);
                }
            }

            #endregion
        }
    }
}