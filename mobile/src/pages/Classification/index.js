import React from 'react';
import { StyleSheet, SafeAreaView } from 'react-native';
import { Divider, TopNavigation } from '@ui-kitten/components';
import { useNavigation } from '@react-navigation/native';
import ImagesScreen from './ImagesScreen';

export const ClassificationScreen = () => {
  const navigation = useNavigation();

  const navigateTags = () => { 
    navigation.navigate('Tags', { options: ['test 1','test 2', 'test 3'] });
  };

  return (
    <SafeAreaView style={{ flex: 1 }}>
      <TopNavigation title='Lookie Looks' alignment='center'/>
      <Divider/>      
      <ImagesScreen classificationHandler={() => navigateTags()}/>
    </SafeAreaView>
  );
};


const styles = StyleSheet.create({
  layout : {
    flex: 1, 
    justifyContent: 'center', 
  },
  buttonGroup: {
    justifyContent: 'center', 
    margin: 2,
  },
  button:{
    width:'100%'
  }
});
