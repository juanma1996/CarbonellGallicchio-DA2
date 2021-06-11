import { CategoryModel } from '../category/category-model';
import { PlaylistBasicInfo } from '../playlist/playlist-basic-info';

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

export interface VideoContentBasicInfo {
    name: string;
    duration: TimeSpan
    creatorName: string;
    videoUrl: string;
    categories: CategoryModel[];
    playlists: PlaylistBasicInfo[];
}
