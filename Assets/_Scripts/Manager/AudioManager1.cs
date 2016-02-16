//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//public enum ESoundName
//{
//    music_menu,
//    music_map,
//    sound_ui006,
//    sound_dig003,
//    sound_dig004,
//    sound_dig005,


//    sound_collect001,
//    sound_collect002,
//    sound_collect003,

//    sound_part010,
//    sound_part011,
//    sound_part013,
//    sound_part014,
//    sound_part015,
//    sound_part016,

//    sound_monster003,
//    sound_monster004,
//    sound_monster005,


//    sound_effect001,

//    sound_hero001,
//    sound_win,
//    sound_lose,
//    sound_battle,
//    sound_logo,

//    sound_monster002,
//    sound_uifight003,
//    sound_uifight002,
//    player_levelup,
//    sound_crown,
//    sound_none = 255,
    
//}

//public struct AudioObject
//{
//    public GameObject clipObject;
//    public GameObject owner;
//}

//public class AudioManager : MonoBehaviour
//{
//    public static string[] sSoundNames = new string[]
//    {
//       "bgm_001",
//       "bgm_002",
//       "sound_ui006",
//      "sound_dig003",
//      "sound_dig004",
//      "sound_dig005",

//      "sound_collect001",
//      "sound_collect002",
//      "sound_collect003",


//      "sound_part010",
//      "sound_part011",
//      "sound_part013",
//      "sound_part014",
//      "sound_part015",
//      "sound_part016",

//      "sound_monster003",
//      "sound_monster004",
//      "sound_monster005",

//      "sound_effect001",

//      "sound_hero001",
//      "bgm_004",
//      "bgm_005",
//      "bgm_003",
//      "bgm_006",

//      "sound_monster002",
//      "sound_uifight003",
//      "sound_uifight002",
//      "sound_fight_skill008",
//      "sound_crown",
//    };

//    public static AudioManager mIns=null;
//    public bool bMuteSound = false;
//    public bool bMuteMusic = false;
//    public float soundVolume = 1.0f;
//    public float musicVolume = 1.0f;
//    protected Dictionary<string, List<AudioObject>> m_soundClips = new Dictionary<string, List<AudioObject>>();
//    protected Dictionary<string, List<GameObject>> m_musicClips = new Dictionary<string, List<GameObject>>();
//    private List<GameObject> mPreLoadSoundList = new List<GameObject>();

//    void Awake()
//    {
//        mIns = this;
//        LoadMusicAndSoundInfo();

//        NGUITools.soundVolume = soundVolume;
//        if (bMuteSound)
//        {
//            NGUITools.soundVolume = 0f;
//        }
//        m_soundClips.Clear();
//        m_musicClips.Clear();
//    }

//    public void Start()
//    {
//        //PlayMusic(ESoundName.music_menu);
//    }

//    public AudioClip LoadMusic(string name)
//    {
//        return Resources.Load("Sound/"+name, typeof(AudioClip)) as AudioClip;
//    }

//    public AudioClip LoadSound(string name)
//    {
//        return Resources.Load("Sound/" + name, typeof(AudioClip)) as AudioClip;
//    }


//    protected void AddSound(string name, AudioObject obj)
//    {
//        if (m_soundClips.ContainsKey(name))
//        {
//            if (m_soundClips[name] == null)
//            {
//                m_soundClips[name] = new List<AudioObject>();
//                m_soundClips[name].Add(obj);
//            }
//            else
//            {
//                for (int i = 0; i < m_soundClips[name].Count;i++ )
//                {
//                    if (m_soundClips[name][i].clipObject == null)
//                    {
//                        m_soundClips[name][i] = obj;
//                        return;
//                    }
//                }
//                m_soundClips[name].Add(obj);
//            }
//        }
//        else
//        {
//            List<AudioObject> lst = new List<AudioObject>();
//            lst.Add(obj);
//            m_soundClips.Add(name, lst);
//        }
//    }

//    protected void AddMusic(string name, GameObject obj)
//    {
//        if (m_musicClips.ContainsKey(name))
//        {
//            if (m_musicClips[name] == null)
//            {
//                m_musicClips[name] = new List<GameObject>();
//                m_musicClips[name].Add(obj);
//            }
//            else
//            {
//                m_musicClips[name].Add(obj);
//            }
//        }
//        else
//        {
//            List<GameObject> lst = new List<GameObject>();
//            lst.Add(obj);
//            m_musicClips.Add(name, lst);
//        }
//    }

//    void OnDestroy()
//    {
//        StopAllMusic();
//        StopAllSound();
//    }

//    public void PlayMusic(ESoundName name, bool isLoop = true)
//    {
//        PlayMusic(sSoundNames[(int)name], isLoop);
//    }
//    public void PlayMusic(string name,bool isLoop = true)
//    {
//        if (IsPlayingMusic(name) && isLoop)
//        {
//            return;
//        }
//        StopAllMusic();
//        AudioClip clip = LoadMusic(name);
//        LogMgr.Log("clip: " + clip);
//        GameObject obj = new GameObject("AudioMusic:" + clip.name);
//        obj.transform.parent = transform;
//        obj.transform.position = transform.position;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.loop = isLoop;
//        source.volume = musicVolume;
//        source.playOnAwake = false;
//        source.mute = bMuteMusic;
//        source.Play();
//        AddMusic(name, obj);
//    }

//    public bool IsPlayingMusic(string name)
//    {
//        if (m_musicClips.ContainsKey(name) && m_musicClips[name].Count > 0)
//        {
//            return true;
//        }
//        return false;
//    }

//    public void StopAllMusic()
//    {
//        foreach (KeyValuePair<string, List<GameObject>> kvp in m_musicClips)
//        {
//            foreach (GameObject obj in kvp.Value)
//            {
//                if (obj != null)
//                {
//                    Destroy(obj);
//                }
//            }
//        }

//        m_musicClips.Clear();
//    }

//    public void StopAllSound()
//    {
//        foreach (KeyValuePair<string, List<AudioObject>> kvp in m_soundClips)
//        {
//            foreach (AudioObject obj in kvp.Value)
//            {
//                if (obj.clipObject != null)
//                {
//                    Destroy(obj.clipObject);
//                }
//            }
//        }

//        m_soundClips.Clear();
//    }
	
//    public void SetSoundMute(bool bMute)
//    {
//        bMuteSound = bMute;
//        if (bMuteSound)
//        {
//            NGUITools.soundVolume = 0f;
//        }
//        else
//        {
//            NGUITools.soundVolume = 1f;
//        }

//        SaveSoundMute (bMuteSound);
		
//        foreach (KeyValuePair<string, List<AudioObject>> kvp in m_soundClips)
//        {
//            foreach (AudioObject obj in kvp.Value)
//            {
//                if(obj.clipObject != null)
//                {
//                    AudioSource source = obj.clipObject.GetComponent(typeof(AudioSource)) as AudioSource;
//                    source.mute = bMute;
//                }
//            }
//        }


//    }
	
//    public void SetMusicMute(bool bMute)
//    {
//        bMuteMusic = bMute;
//        SaveMusicMute (bMuteMusic);
		
//        foreach (KeyValuePair<string, List<GameObject>> kvp in m_musicClips)
//        {
//            foreach (GameObject obj in kvp.Value)
//            {
//                if(obj != null)
//                {
//                    AudioSource source = obj.GetComponent(typeof(AudioSource)) as AudioSource;
//                    source.mute = bMute;
//                }
//            }
//        }
//    }
	
//    public void SetSoundVolume(float volume)
//    {
//        soundVolume = volume;
//        SaveSoundVolume (volume);
//        foreach (KeyValuePair<string, List<AudioObject>> kvp in m_soundClips)
//        {
//            foreach (AudioObject obj in kvp.Value)
//            {
//                if (obj.clipObject != null)
//                {
//                    if(obj.clipObject != null)
//                    {
//                        AudioSource source = obj.clipObject.GetComponent(typeof(AudioSource)) as AudioSource;
//                        source.volume = volume;
//                    }
//                }
//            }
//        }
//    }
	
//    public void SetMusicVolume(float volume)
//    {
//        musicVolume = volume;
//        SaveMusicVolume (volume);
//        foreach (KeyValuePair<string, List<GameObject>> kvp in m_musicClips)
//        {
//            foreach (GameObject obj in kvp.Value)
//            {
//                if(obj != null)
//                {
//                    AudioSource source = obj.GetComponent(typeof(AudioSource)) as AudioSource;
//                    source.volume = volume;
//                }
//            }
//        }
//    }

//    public void PlaySound(string name, GameObject owner, Vector3 pos, AudioRolloffMode mode, float maxDistance, bool isLoop, float loopLiftTime = -1f)
//    {
//        if (soundVolume == 0 || bMuteSound)
//            return;

//        AudioClip clip = LoadSound(name);

//        GameObject obj = new GameObject("AudioSound::" + clip.name);
//        AudioObject audioObject = new AudioObject();
//        audioObject.clipObject = obj;
//        audioObject.owner = owner;
//        obj.transform.parent = owner.transform;
//        obj.transform.position = pos;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.volume = soundVolume;
//        source.loop = isLoop;
//        source.maxDistance = maxDistance;
//        source.Play();
//        source.rolloffMode = mode;
//        source.playOnAwake = false;
//        source.mute = bMuteSound;
//        AddSound(name, audioObject);
//        if (isLoop == false)
//        {
//            Destroy(obj, clip.length);
//        }
//        else if (loopLiftTime > 0)
//        {
//            Destroy(obj, loopLiftTime);
//        }
//    }

//    #region Global Sound

//    public void PlaySoundAt(string name, Vector3 pos)
//    {
//        PlaySoundAt(name, null, pos);
//    }

//    public void PlaySoundAt(string name, Vector3 pos, AudioRolloffMode mode, float maxDistance)
//    {
//        PlaySoundAt(name, null, pos, mode, maxDistance);
//    }

//    public void PlaySound(string name)
//    {
//        PlaySound(name, null);
//    }

//    public void PlaySound(ESoundName name)
//    {
//        PlaySound(sSoundNames[(int)name], null);
//    }

//    public void PlaySound(AudioClip ac,AudioSource aus)
//    {
//        if (soundVolume == 0 || bMuteSound)
//            return;
//        aus.clip = ac;
//        aus.volume = soundVolume;
//        aus.Play();
//    }

//    public void PlaySoundLoop(string name)
//    {
//        PlaySoundLoop(name, null);
//    }

//    public void PlaySoundSingle(string name)
//    {
//        if (IsPlayingSound(name))
//        {
//            return;
//        }
//        PlaySound(name);
//    }

//    public void PlaySoundSingleLoop(string name)
//    {
//        if (IsPlayingSound(name))
//        {
//            return;
//        }

//        PlaySoundLoop(name);
//    }

//    public bool IsPlayingSound(string name)
//    {
//        if (m_soundClips.ContainsKey(name) && m_soundClips[name].Count > 0)
//        {
//            for (int i = 0; i < m_soundClips[name].Count; i++)
//            {
//                if (m_soundClips[name][i].clipObject != null)
//                {
//                    return true;
//                }
//            }

//            m_soundClips[name].Clear();
//            return false;
//        }

//        return false;
//    }

//    public void PlaySoundSingleAt(string name, Vector3 pos)
//    {
//        if (IsPlayingSound(name))
//        {
//            return;
//        }

//        PlaySoundAt(name, pos);
//    }

//    public void PlaySoundSingleAt(string name, Vector3 pos, AudioRolloffMode mode, float maxDistance)
//    {
//        if (IsPlayingSound(name))
//        {
//            return;
//        }

//        PlaySoundAt(name, pos, mode, maxDistance);
//    }

//    public void StopSound(string name)
//    {
//        if (m_soundClips.ContainsKey(name))
//        {
//            foreach (AudioObject obj in m_soundClips[name])
//            {
//                if (obj.clipObject != null)
//                {
//                    Destroy(obj.clipObject);
//                }
//            }

//            m_soundClips[name].Clear();
//            m_soundClips.Remove(name);
//        }
//    }

//    #endregion

//    #region GameObject Sound

//    public void PlaySoundAt(string name, GameObject owner, Vector3 pos)
//    {
//        if (soundVolume == 0 || bMuteSound)
//            return;
//        AudioClip clip = LoadSound(name);
//        GameObject obj = new GameObject("AudioSound::" + clip.name);
//        AudioObject audioObject = new AudioObject();
//        audioObject.clipObject = obj;
//        audioObject.owner = owner;
//        obj.transform.parent = transform;
//        obj.transform.position = pos;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.volume = soundVolume;
//        source.maxDistance = 300f;
//        source.Play();
//        source.rolloffMode = AudioRolloffMode.Linear;
//        source.playOnAwake = false;
//        source.mute = bMuteSound;
//        AddSound(name, audioObject);
//        Destroy(obj, clip.length);
//    }

//    public void PlaySoundAt(string name, GameObject owner, Vector3 pos, AudioRolloffMode mode, float maxDistance)
//    {
//        if (soundVolume == 0 || bMuteSound)
//            return;
//        AudioClip clip = LoadSound(name);
//        GameObject obj = new GameObject("AudioSound::" + clip.name);
//        AudioObject audioObject = new AudioObject();
//        audioObject.clipObject = obj;
//        audioObject.owner = owner;
//        obj.transform.parent = transform;
//        obj.transform.position = pos;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.volume = soundVolume;
//        source.maxDistance = maxDistance;
//        source.Play();
//        source.rolloffMode = mode;
//        source.playOnAwake = false;
//        source.mute = bMuteSound;
//        AddSound(name, audioObject);
//        Destroy(obj, clip.length);
//    }

//    public void PlaySound(string name, GameObject owner)
//    {

//        if (soundVolume == 0 || bMuteSound)
//            return;
//        AudioClip clip = LoadSound(name.Trim());
//        GameObject obj = new GameObject("AudioSound::" + clip.name);
//        AudioObject audioObject = new AudioObject();
//        audioObject.clipObject = obj;
//        audioObject.owner = owner;
//        obj.transform.parent = transform;
//        obj.transform.position = transform.position;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.volume = soundVolume;
//        source.Play();
//        source.playOnAwake = false;
//        source.mute = bMuteSound;
//        AddSound(name, audioObject);
//        Destroy(obj, clip.length);
//    }


//    public void PlaySoundLoop(string name, GameObject owner)
//    {
//        if (soundVolume == 0 || bMuteSound)
//            return;

//        AudioClip clip = LoadSound(name);

//        GameObject obj = new GameObject("AudioSound::" + clip.name);
//        AudioObject audioObject = new AudioObject();
//        audioObject.clipObject = obj;
//        audioObject.owner = owner;
//        obj.transform.parent = transform;
//        obj.transform.position = transform.position;
//        AudioSource source = obj.AddComponent(typeof(AudioSource)) as AudioSource;
//        source.clip = clip;
//        source.volume = soundVolume;
//        source.loop = true;
//        source.Play();
//        source.playOnAwake = false;
//        source.mute = bMuteSound;
//        AddSound(name, audioObject);
//        Destroy(obj, clip.length);
//    }

//    public void PlaySoundSingle(string name, GameObject owner)
//    {
//        if (IsPlayingSound(name, owner))
//        {
//            return;
//        }

//        PlaySound(name, owner);
//    }

//    public void PlaySoundSingleLoop(string name, GameObject owner)
//    {
//        if (IsPlayingSound(name, owner))
//        {
//            return;
//        }

//        PlaySoundLoop(name, owner);
//    }

//    public void PlaySoundSingleLoopAt(string name, GameObject owner, Vector3 pos, AudioRolloffMode mode, float maxDistance)
//    {
//        if (IsPlayingSound(name, owner))
//        {
//            return;
//        }

//        PlaySound(name, owner, pos, mode, maxDistance,true);
//    }

//    public bool IsPlayingSound(string name, GameObject owner)
//    {
//        if (m_soundClips.ContainsKey(name) && m_soundClips[name].Count > 0)
//        {
//            bool needClear = true;
//            for (int i = 0; i < m_soundClips[name].Count; i++)
//            {
//                if (m_soundClips[name][i].clipObject != null)
//                {
//                    needClear = false;

//                    if (m_soundClips[name][i].owner == owner)
//                    {
//                        return true;
//                    }
//                }
//            }

//            if (needClear)
//                m_soundClips[name].Clear();

//            return false;
//        }

//        return false;
//    }

//    public void PlaySoundSingleAt(string name, GameObject owner, Vector3 pos)
//    {
//        if (IsPlayingSound(name, owner))
//        {
//            return;
//        }

//        PlaySoundAt(name, owner, pos);
//    }

//    public void PlaySoundSingleAt(string name, GameObject owner, Vector3 pos, AudioRolloffMode mode, float maxDistance)
//    {
//        if (IsPlayingSound(name, owner))
//        {
//            return;
//        }

//        PlaySoundAt(name, owner, pos, mode, maxDistance);
//    }

//    public void StopSound(string name, GameObject owner)
//    {
//        if (m_soundClips.ContainsKey(name))
//        {
//            List<AudioObject> toClearList = new List<AudioObject>();

//            foreach (AudioObject obj in m_soundClips[name])
//            {
//                if (obj.owner == owner)
//                {
//                    toClearList.Add(obj);

//                    if (obj.clipObject != null)
//                    {
//                        Destroy(obj.clipObject);
//                    }
//                }
//            }

//            foreach (AudioObject obj in toClearList)
//            {
//                if (m_soundClips[name].Contains(obj))
//                {
//                    m_soundClips[name].Remove(obj);
//                }
//            }
            
//            if (m_soundClips[name].Count == 0)
//                m_soundClips.Remove(name);
//        }
//    }

//    public void StopSound(GameObject owner)
//    {
//        foreach (KeyValuePair<string, List<AudioObject>> kvp in m_soundClips)
//        {
//            foreach (AudioObject obj in kvp.Value)
//            {
//                if (obj.owner == owner && obj.clipObject != null)
//                {
//                    Destroy(obj.clipObject);
//                }
//            }
//        }

//        m_soundClips.Clear();
//    }


//    public void LoadMusicAndSoundInfo()
//    {
//        bMuteMusic = LoadMusicMute ();
//        bMuteSound = LoadSoundMute ();
//        musicVolume = LoadMusicVolume ();
//        soundVolume = LoadSoundVolume ();
//    }

//    public void SaveMusicMute(bool bMute)
//    {
//        if(bMute)
//        {
//            PlayerPrefs.SetInt("bMusicMute", 1);
//        }
//        else
//        {
//            PlayerPrefs.SetInt("bMusicMute", 0);
//        }
//    }
	
//    public bool LoadMusicMute()
//    {
//        bool _bMusicMute = false;
//        int musicMute = PlayerPrefs.GetInt ("bMusicMute", 0);
//        if(musicMute > 0)
//        {
//            _bMusicMute = true;
//        }
//        else
//        {
//            _bMusicMute = false;
//        }
//        return _bMusicMute;
//    }
	
//    public void SaveMusicVolume(float volume)
//    {
//        PlayerPrefs.SetFloat("musicVolume", volume);
//    }
	
//    public float LoadMusicVolume()
//    {
//        return PlayerPrefs.GetFloat ("musicVolume", 1f);
//    }
	
//    public void SaveSoundMute(bool bMute)
//    {
//        if(bMute)
//        {
//            PlayerPrefs.SetInt("bSoundMute", 1);
//        }
//        else
//        {
//            PlayerPrefs.SetInt("bSoundMute", 0);
//        }
//    }
	
//    public bool LoadSoundMute()
//    {
//        bool _bSoundcMute = false;
//        int soundMute = PlayerPrefs.GetInt ("bSoundMute", 0);
//        if(soundMute > 0)
//        {
//            _bSoundcMute = true;
//        }
//        else
//        {
//            _bSoundcMute = false;
//        }
//        return _bSoundcMute;
//    }
	
//    public void SaveSoundVolume(float volume)
//    {
//        PlayerPrefs.SetFloat("soundVolume", volume);
//    }
	
//    public float LoadSoundVolume()
//    {
//        return PlayerPrefs.GetFloat ("soundVolume", 1f);
//    }

//    #endregion
//}

