import { PlaylistBasicInfo } from '../playlist/playlist-basic-info';
import { CategoryModel } from '../category/category-model';
import { PlaylistModel } from '../playlist/playlist-model';

export interface AudioContentModel {
    name: string;
    duration: string
    creatorName: string;
    imageUrl: string;
    audioUrl: string;
    categories: CategoryModel[];
    playlists: PlaylistBasicInfo[];
}
