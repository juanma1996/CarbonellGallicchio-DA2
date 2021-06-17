import { CategoryModel } from '../category/category-model';
import { PlaylistBasicInfo } from '../playlist/playlist-basic-info';

export interface VideoContentBasicInfo {
    name: string;
    duration: string
    creatorName: string;
    videoUrl: string;
    categories: CategoryModel[];
    playlists: PlaylistBasicInfo[];
}
