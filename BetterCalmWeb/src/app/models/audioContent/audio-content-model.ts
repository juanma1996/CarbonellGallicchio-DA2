import { PlaylistBasicInfo } from '../playlist/playlist-basic-info';
import { CategoryModel } from '../category/category-model';
import { PlaylistModel } from '../playlist/playlist-model';

export interface TimeSpan {
    ticks: number,
    days: number,
    hours: number,
    miliseconds: number,
    minutes: number,
    seconds: number,
    totalDays: number,
    totalHours: number,
    totalMilliseconds: number,
    totalMinutes: number,
    totalSeconds: number,
}

export interface AudioContentModel {
    name: string;
    duration: TimeSpan
    creatorName: string;
    imageUrl: string;
    audioUrl: string;
    categories: CategoryModel[];
    playlists: PlaylistBasicInfo[];
}
