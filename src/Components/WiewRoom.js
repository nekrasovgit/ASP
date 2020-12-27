import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';


const useStyles = makeStyles((theme) => ({
  root: {
    marginTop: 100,
    display: 'flex',
    flexWrap: 'wrap',
    justifyContent: 'space-around',
    overflow: 'hidden',

  },
  gridList: {
    width: 600,
    height: 500,

    paddingTop: theme.spacing(8),
        paddingBottom: theme.spacing(8),
    
  },

  contain: {
    height: 500,

  }

}));

function WiewRoom() {
    const classes = useStyles();



    return(
        <React.Fragment>
            <CssBaseline />
            <Container maxWidth="xl"  className={classes.contain}>
                <Paper elevation={3}>               
                    <div className={classes.root}>
                        <GridList cellHeight={400} className={classes.gridList} cols={2}>
                            <GridListTile >
                                <img src="https://source.unsplash.com/random" alt="Image" />
                            </GridListTile>                  
                        </GridList>
                        <Typography gutterBottom variant="h5" component="h2">
                            Hello
                        </Typography>
                    </div>
                </Paper>
            </Container>
        </React.Fragment>
    );
}
export default WiewRoom;

/*<CssBaseline />
            <Container maxWidth="xl"></Container>*/