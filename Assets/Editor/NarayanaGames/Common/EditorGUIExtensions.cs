/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  All rights reserved                             *
 ****************************************************/

using UnityEditor;
using UnityEngine;

namespace NarayanaGames.UnityEditor.Common {
    /// <summary>
    ///     This class provides a couple of useful methods for creating custom
    ///     editor scripts.
    /// </summary>
    public class EditorGUIExtensions {

        /// <summary>
        ///     Draws a slider that can be used to control Time.timeScale.
        /// </summary>
        public static void TimeScaleSlider() {
            GUIContent contentTimeScale = new GUIContent("Time.timeScale",
                "Conveniently control the timescale from here to test its effects on your settings");
            Time.timeScale = EditorGUILayout.Slider(contentTimeScale, Time.timeScale, 0, 2);
        }

        /// <summary>
        ///     Draws a nice int slider for custom inspectors.
        /// </summary>
        /// <param name="prop">the property to be controlled be this slider</param>
        /// <param name="min">min value for the property</param>
        /// <param name="max">max value for the property</param>
        /// <param name="content">the label for this slider</param>
        public static void NiceIntSlider(SerializedProperty prop, int min, int max, GUIContent content) {
            IndentedLabel(content);

            EditorGUILayout.BeginHorizontal();
            {
                InsertLeftIndentation(true);
                EditorGUILayout.IntSlider(prop, min, max, "");
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        ///     Draws a nice float slider for custom inspectors.
        /// </summary>
        /// <param name="prop">the property to be controlled be this slider</param>
        /// <param name="min">min value for the property</param>
        /// <param name="max">max value for the property</param>
        /// <param name="content">the label for this slider</param>
        public static void NiceFloatSlider(SerializedProperty prop, float min, float max, GUIContent content) {
            IndentedLabel(content);

            EditorGUILayout.BeginHorizontal();
            {
                InsertLeftIndentation(true);
                EditorGUILayout.Slider(prop, min, max, "");
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        ///     Draws a nice Vector2 field.
        /// </summary>
        /// <param name="prop">the property</param>
        /// <param name="content">a label with tooltip</param>
        public static void NiceVector2Field(SerializedProperty prop, GUIContent content) {
            EditorGUILayout.BeginHorizontal();
            {
                InsertLeftIndentation(true);
                prop.vector2Value = EditorGUILayout.Vector2Field(content.text, prop.vector2Value);
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        ///     Draws a nice Vector3 field.
        /// </summary>
        /// <param name="prop">the property</param>
        /// <param name="content">a label with tooltip</param>
        public static void NiceVector3Field(SerializedProperty prop, GUIContent content) {
            EditorGUILayout.BeginHorizontal();
            {
                InsertLeftIndentation(true);
                prop.vector3Value = EditorGUILayout.Vector3Field(content.text, prop.vector3Value);
            }
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        ///     Draws a label which is indented according to EditorGUI.indentLevel.
        /// </summary>
        /// <param name="content">the text to be drawn</param>
        public static void IndentedLabel(GUIContent content) {
            EditorGUILayout.BeginHorizontal();
            {
                InsertLeftIndentation(true);
                GUILayout.Label(content);
                GUILayout.FlexibleSpace();
            }
            EditorGUILayout.EndHorizontal();
        }

        private static void InsertLeftIndentation(bool initialIndent) {
            if (initialIndent) {
                GUILayout.Space(13);
            }
            for (int i = 0; i < EditorGUI.indentLevel; i++) {
                GUILayout.Space(15);
            }
        }

        /// <summary>
        ///     Draws an array or list just like the default inspector would.
        ///     One problem with this: It seems to ignore EditorGUI.indentLevel :-(
        /// </summary>
        /// <param name="target">the object that is being edited</param>
        /// <param name="prop">the property of <c>target</c> to be edited</param>
        /// <param name="content">label and tooltip</param>
        public static void ArrayWithFoldout(SerializedObject target, SerializedProperty prop, GUIContent content) {
            int indentLevel = EditorGUI.indentLevel;

            string propName = prop.name;
            bool showChildren = false;
            SerializedProperty propertyIterator = target.FindProperty(propName);
            do {
                if (propertyIterator.propertyPath != propName 
                    && !propertyIterator.propertyPath.StartsWith(string.Format("{0}.", propName))) {
                    break;
                }
                EditorGUILayout.BeginHorizontal();
                {
                    InsertLeftIndentation(false);
                    if (content != null) {
                        showChildren = EditorGUILayout.PropertyField(propertyIterator, content);
                        content = null; // "consumed" ;-)
                    } else {
                        showChildren = EditorGUILayout.PropertyField(propertyIterator);
                    }
                }
                EditorGUILayout.EndHorizontal();

            } while (propertyIterator.NextVisible(showChildren));

            EditorGUI.indentLevel = indentLevel;
        }

        /// <summary>
        ///     Draws a nice red warning label in a custom inspector.
        /// </summary>
        /// <param name="text">the text for the warning</param>
        public static void LabelWarning(string text) {
            LabelWithColor(text, Color.red, null, null, null);
        }

        /// <summary>
        ///     Draws a nice info label in a custom inspector.
        /// </summary>
        /// <param name="text">the text for the info</param>
        public static void LabelInfo(string text) {
            Color normalTextColor = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label.normal.textColor;
            LabelWithColor(text, normalTextColor, null, null, null);
        }

        /// <summary>
        ///     Draws a nice label for documentation.
        /// </summary>
        /// <param name="text">the text for the info</param>
        public static void LabelDocs(string text) {
            Color normalTextColor = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label.normal.textColor;
            LabelWithColor(text, normalTextColor, EditorStyles.standardFont, TextAnchor.UpperLeft, 50F);
        }

        private static void LabelWithColor(string text, Color color, Font font, TextAnchor? anchor, float? left) {
            GUISkin skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
            GUIStyle style = new GUIStyle(skin.box); //new GUIStyle(skin.label);
            style.normal.textColor = color;
            style.wordWrap = true;
            style.alignment = TextAnchor.UpperCenter;
            style.richText = true;
            if (anchor != null) {
                style.alignment = anchor.Value;
            }
            if (font != null) {
                style.font = font;
            }
            GUILayout.BeginHorizontal();
            {
                if (!left.HasValue) {
                    GUILayout.Space(20F);
                } else {
                    GUILayout.Space(left.Value);
                }
                GUILayout.Box(text, style, GUILayout.ExpandWidth(true));
                GUILayout.Space(20F);
            }
            GUILayout.EndHorizontal();
        }

        /// <summary>
        ///     Draws a fold out which stays open or closed between editor sessions. 
        ///     Do not use in your scripts because it uses editor prefs
        ///     in a specific namespace that only I am allowed to use ;-) don't blame me
        ///     if you use it and the Universe collapses - you have been warned!
        /// </summary>
        /// <param name="label">the label for the foldout</param>
        /// <param name="editorPrefsKey">the (unique) key for the editor prefs to store the state</param>
        /// <param name="def">the default value (<c>true</c> means open, <c>false</c> means closed)</param>
        /// <returns>the current foldout state</returns>
        public static bool PersistentFoldout(string label, string editorPrefsKey, bool def) {
            bool currentSetting = GetEditorPrefsSettingBool(editorPrefsKey, def);
            currentSetting = EditorGUILayout.Foldout(currentSetting, label);
            if (GUI.changed) {
                SetEditorPrefsSettingBool(editorPrefsKey, currentSetting);
            }
            return currentSetting;
        }

        /// <summary>
        ///     Draws a persistent toggle which is used e.g. for switching between the default 
        ///     inspector and my custom inspector or whether play mode changes shall be
        ///     persisted. This automatically stores its state to the editor prefs so that
        ///     it remembers its state between Unity sessions.
        ///     Do not use in your scripts because it uses editor prefs
        ///     in a specific namespace that only I am allowed to use ;-) don't blame me
        ///     if you use it and the Universe collapses - you have been warned!
        /// </summary>
        /// <param name="label">the label for the toggle</param>
        /// <param name="editorPrefsKey">the (unique) key for the editor prefs to store the state</param>
        /// <param name="def">the default value</param>
        /// <returns></returns>
        public static bool PersistentToggle(string label, string editorPrefsKey, bool def) {
            bool editorSetting = GetEditorPrefsSettingBool(editorPrefsKey, def);
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                editorSetting = GUILayout.Toggle(editorSetting, label, GUILayout.Width(150F));
                if (GUI.changed) {
                    SetEditorPrefsSettingBool(editorPrefsKey, editorSetting);
                }
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndHorizontal();
            return editorSetting;
        }

        /// <summary>
        ///     Prefixes editor pref keys with <c>NarayanaGames.</c> to make sure 
        ///     I don't overwrite other plugins' settings (or other plugins overwrite
        ///     my settings).
        /// </summary>
        /// <param name="editorPrefsKey">the (unique) key for the editor prefs</param>
        /// <param name="def">the default value</param>
        /// <returns>the current value</returns>
        public static bool GetEditorPrefsSettingBool(string editorPrefsKey, bool def) {
            string fullKey = string.Format("NarayanaGames.{0}", editorPrefsKey);
            return EditorPrefs.GetBool(fullKey, def);
        }

        /// <summary>
        ///     Prefixes editor pref keys with <c>NarayanaGames.</c> to make sure 
        ///     I don't overwrite other plugins' settings (or other plugins overwrite
        ///     my settings).
        /// </summary>
        /// <param name="editorPrefsKey">the (unique) key for the editor prefs</param>
        /// <param name="val">the new value</param>
        public static void SetEditorPrefsSettingBool(string editorPrefsKey, bool val) {
            string fullKey = string.Format("NarayanaGames.{0}", editorPrefsKey);
            EditorPrefs.SetBool(fullKey, val);
        }

   }
}