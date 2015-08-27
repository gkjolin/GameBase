using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace AnimationEventUtility {

internal sealed class AddAnimationEventPostProcess : AssetPostprocessor {

		string[] seperator = new string[] {"\t"};
		int[] column = new int[(int)Property._Count];
		int columnDefined = 0;
		bool requiredColumnsDefined = false;

		enum Property {
			name = 0,
			first,
			last,
			loop,
			events,

			_Count
		}

	void OnPostprocessModel (GameObject obj)
	{
		ModelImporter importer = assetImporter as ModelImporter;
		string path = importer.assetPath;
		//fetch animation config from ../[name].txt
		int extensionSplit = path.LastIndexOf ('.');
		string configPath = path.Remove (extensionSplit) + ".txt";
			if (!File.Exists (configPath)) return;
			Debug.Log ("Postprocessing model @ path : " + path);
		StreamReader reader = new StreamReader (configPath);
		List<ModelImporterClipAnimation> clips = new List<ModelImporterClipAnimation> ();
		string[] elements;
		ModelImporterClipAnimation clip;
		int lineNumber = 0;
			int eventTotal = 0;
		string[] eventParameters;
		char[] eventSeperators = new char[] {'@', ';'};
		float frameLength;
		string line;
		try {
			while (!reader.EndOfStream) {
					line = reader.ReadLine ();
					lineNumber++;
					if (line.StartsWith("//")) continue;
					if (!requiredColumnsDefined) {
						if (line.StartsWith ("#")) {
							string[] argument = line.Split (new char[] {' ', '=', '[', ']', '\'', '\"'}, System.StringSplitOptions.RemoveEmptyEntries);
							//Debug.Log ("argument[0] = " + argument[0]);
							if (argument[0].Equals("#seperator")) {
								seperator = new string[] {argument[1]};
								//Debug.Log ("seperator = " + seperator[0]);
							} else {
								
							}
						} else {
							string[] columns = line.Split (seperator, System.StringSplitOptions.RemoveEmptyEntries);
							for (int o = 0; o < columns.Length; o++) {
								//Debug.Log (columns[o]);
								for (Property r = (Property)0; r < Property._Count; r++)
								{
									if (columns[o].Equals (r.ToString ())) {
										column[(int)r] = o;
										columnDefined++;
									}
								}
							}
							if (!(requiredColumnsDefined = (columnDefined == (int)Property._Count))) {
								Debug.LogError ("property not found!");
								return;
							}
						}
					} else {
						elements = line.Split(seperator, System.StringSplitOptions.None);
                        
						clip = new ModelImporterClipAnimation ();
						clips.Add (clip);
						clip.name = elements[column[(int)Property.name]];
						clip.firstFrame = float.Parse (elements[column[(int)Property.first]]);
						clip.lastFrame = float.Parse (elements[column[(int)Property.last]]);
						if (elements.Length > column[(int)Property.loop])
							clip.loopTime = bool.Parse (elements[column[(int)Property.loop]]);
                        if (elements.Length > column[(int)Property.events])
                        {
                            string eventsStr = elements[column[(int)Property.events]];
                            Debug.Log(clip.name + "------------------->" + eventsStr);
                            if (!string.IsNullOrEmpty(eventsStr))
                            {
                                frameLength = clip.lastFrame - clip.firstFrame;
                                eventParameters = eventsStr.Split(eventSeperators);
                                Debug.Log(clip.name + "------------------->eventParameters------>" + eventParameters.Length.ToString());
                                if (eventParameters.Length % 3 != 0) throw new System.FormatException("event parameters' size mismatch.");
                                int eventCount = eventParameters.Length / 3;
                                AnimationEvent[] events = new AnimationEvent[eventCount];
                                for (int i = 0; i < eventCount; i++)
                                {
                                    events[i] = new AnimationEvent();
                                    eventTotal++;
                                    events[i].functionName = ((AnimationEventFunction)(int.Parse(eventParameters[3 * i]))).ToString();
                                    if (!string.IsNullOrEmpty(eventParameters[3 * i + 1]))
                                        events[i].intParameter = int.Parse(eventParameters[3 * i + 1]);

                                    //events[i].time = (float.Parse(eventParameters[3 * i + 2]) - clip.firstFrame) / frameLength;
                                    events[i].time = (float.Parse(eventParameters[3 * i + 2])) / frameLength;

                                    Debug.Log(events[i].functionName +"["+clip.firstFrame.ToString()+":"+clip.lastFrame.ToString()+"] at " + events[i].time.ToString());
                                }
                                clip.events = events;
                            }
                        }
					}
			}
		}
		catch (System.Exception e) {
			Debug.LogError ("exception on line " + lineNumber + " : " + e.Message);
		}
			finally {
				reader.Close ();
			}
			/*
		for (int i = 0; i < importedAnims.Length; i++) {
			clips[i] = new ModelImporterClipAnimation ();
			clips[i].name = "clip " + i;
			clips[i].firstFrame = importedAnims[i].firstFrame;
			clips[i].lastFrame = importedAnims[i].lastFrame;
			clips[i].loop = importedAnims[i].loop;
			AnimationEvent evStart = new AnimationEvent ();
			evStart.functionName = "AnimationStart_";
			evStart.time = 0;
			AnimationEvent evEnd = new AnimationEvent ();
			evEnd.functionName = "AnimationEnd_";
			evEnd.time = 1;
			clips[i].events = new AnimationEvent[] {evStart, evEnd};
		}
		*/
		importer.clipAnimations = clips.ToArray();
			Debug.Log ("Postprocessed model @ path : " + path + ". animation : " + clips.Count + " events : " + eventTotal);
	}
}
}