#if UNITY_2020_1_OR_NEWER
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;


namespace Autotiles3D
{


    public class Autotiles3D_SettingsProvider : SettingsProvider
    {
        private Autotiles3D_Settings _settings;
        class Styles
        {
            public static GUIContent UndoAPI = new GUIContent("Don't use Undo API");
        }

        public Autotiles3D_SettingsProvider(string path, SettingsScope scope = SettingsScope.User)
            : base(path, scope) { }

        public static bool IsSettingsAvailable()
        {
            var settings = Autotiles3D_Settings.EditorInstance;
            return (settings != null);
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            // This function is called when the user clicks on the MyCustom element in the Settings window.
            _settings = Autotiles3D_Settings.EditorInstance;
        }

        public override void OnGUI(string searchContext)
        {
            // Use IMGUI to display UI:
            if (_settings != null)
            {
                EditorGUILayout.LabelField("(Experimental)");
                _settings.DontRegisterUndo = EditorGUILayout.Toggle(Styles.UndoAPI, _settings.DontRegisterUndo);
            }
        }

        // Register the SettingsProvider
        [SettingsProvider]
        public static SettingsProvider CreateAutotilesSettingsProvider()
        {
            if (IsSettingsAvailable())
            {
                var provider = new Autotiles3D_SettingsProvider("Project/Autotiles3D", SettingsScope.Project);

                // Automatically extract all keywords from the Styles.
                provider.keywords = GetSearchKeywordsFromGUIContentProperties<Styles>();
                return provider;
            }

            // Settings Asset doesn't exist yet; no need to display anything in the Settings window.
            return null;
        }
    }

}
#endif

