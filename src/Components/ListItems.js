import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

export const mainListItems = (
    <div>
        <ListItem button>
            <ListItemText primary="Add Room" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="Edit Room" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="Delete Room" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="" />
        </ListItem>
    </div>
);

export const secondaryListItems = (
    <div>
        <ListItem button>
            <ListItemText primary="" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="" />
        </ListItem>
        <ListItem button>
            <ListItemText primary="" />
        </ListItem>
    </div>
);