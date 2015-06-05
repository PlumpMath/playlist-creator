#!/usr/bin/env bash

vlc='/Applications/VLC.app/Contents/MacOS/VLC'
mono /Users/mklaber/Code/playlist-creator/playlist-creator/bin/Debug/playlist-creator.exe
$vlc play.m3u --fullscreen --video-on-top --no-video-deco --image-duration=300 --no-osd 