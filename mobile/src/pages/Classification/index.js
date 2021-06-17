import React, {useEffect, useState} from 'react';
import { SafeAreaView } from 'react-native';
import { Divider, TopNavigation, Spinner } from '@ui-kitten/components';
import { useNavigation } from '@react-navigation/native';
import ImagesScreen from './ImagesScreen';
import {getGame, vote} from '../../sevices/api';

export const ClassificationScreen = ({userId}) => {
  const [loading, setLoading] = useState(false);
  const [game, setGame] = useState({});
  const navigation = useNavigation();  
  
  const loadGame = async () => {
      if(loading) {
        return;
      }
      
      setLoading(true);

      const loadedGame = await getGame(userId);

      setGame(loadedGame)
      setLoading(false)
    }

  useEffect(() => {
    loadGame();
  }, []);

  const navigateTags = () => { 
    navigation.navigate('Tags', { 
      options: game.options,  
      selectionHandler: (value) => { 
        vote({userId, gameId: game.id, value});
        loadGame();
      }
    });
  };

  const skipGame = () => {
      loadGame();
  }

  return (
    <SafeAreaView style={{ flex: 1 }}>
      {loading && <Spinner/>}
      <TopNavigation title='Lookie Looks' alignment='center'/>
      <Divider/>      
      <ImagesScreen 
        question={game.attribute} 
        images={game.images} 
        classificationHandler={() => navigateTags()}
        skipHandler={skipGame}
      />
    </SafeAreaView>
  );
};